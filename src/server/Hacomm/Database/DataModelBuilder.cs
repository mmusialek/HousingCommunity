﻿using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database;
static class DataModelBuilder
{
    public delegate void BuildModelExt(ModelBuilder builder);

    internal static void BuildAll(this ModelBuilder builder)
    {
        builder.UseCollation("en_US.utf8");

        var builderList = new List<BuildModelExt>
        {
            AddressModelBuilder.Build,
            AnnouncementModelBuilder.Build,
            CalendarEventModelBuilder.Build,
            EvidenceItemModelBuilder.Build
        };

        foreach (var builderItem in builderList)
        {
            builderItem(builder);
        }
        //builder.AddressBuilder();
        //builder.AnnouncementBuilder();
        //builder.HousingCommunityBuilder();
        //builder.UserBuilder();
        //builder.UserMeters();
    }

    //private static void AddressBuilder(this ModelBuilder builder)
    //{
    //    AddressModelBuilder.Build(builder);
    //}

    //private static void AnnouncementBuilder(this ModelBuilder builder)
    //{
    //    AnnouncementModelBuilder.Build(builder);
    //}

    //private static void CalendarEventBuilder(this ModelBuilder builder)
    //{
    //    CalendarEventModelBuilder.Build(builder);
    //}

    private static void UserBuilder(this ModelBuilder builder)
    {
        var entity = builder.Entity<User>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.FirstName).HasMaxLength(100).IsRequired();
        entity.Property(q => q.LastName).HasMaxLength(100).IsRequired();

        entity.HasOne(q => q.Address).WithMany(q => q.Users).HasForeignKey(q => q.AddressId);
        entity.HasMany(q => q.HousingCommunities).WithMany(q => q.Users);
    }

    private static void HousingCommunityBuilder(this ModelBuilder builder)
    {
        var entity = builder.Entity<HousingCommunity>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Name).HasMaxLength(255).IsRequired();

        entity.HasOne(q => q.Address).WithMany(q => q.HousingCommunities).HasForeignKey(q => q.AddressId).IsRequired();
        //obj.HasIndex(q => new
        //{
        //    q.Name,
        //    q.EdMarketId
        //}).IsUnique();

        //obj.HasOne(q => q.StarSystem).WithMany(q => q.Stations).HasForeignKey(q => q.StarSystemId);
    }

    private static void UserMeters(this ModelBuilder builder)
    {
        // meter types
        var meterType = builder.Entity<UserMeterType>();
        meterType.HasKey(q => q.Id);
        meterType.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        meterType.Property(q => q.Name).HasMaxLength(100).IsRequired();
        meterType.Property(q => q.UnitType).HasMaxLength(10).IsRequired();
        meterType.Property(q => q.Description).HasMaxLength(500).IsRequired(false);
        meterType.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        meterType.HasOne(q => q.HousingCommunity).WithMany(q => q.UserMeterTypes).HasForeignKey(q => q.HousingCommunityId);


        // meters
        var meter = builder.Entity<UserMeter>();
        meter.HasKey(q => q.Id);
        meter.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        meter.Property(q => q.Value).IsRequired();
        meter.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        meter.HasOne(q => q.CreatedBy).WithMany(q => q.UserMeters).HasForeignKey(q => q.CreatedBy);
        meter.HasOne(q => q.UserMeterType).WithMany(q => q.UserMeters).HasForeignKey(q => q.UserMeterTypeId);
    }
}
