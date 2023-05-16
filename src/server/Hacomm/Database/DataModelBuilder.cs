using Hacomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database;
static class DataModelBuilder
{
    internal static void BuildAll(this ModelBuilder builder)
    {
        builder.UseCollation("en_US.utf8");
        builder.AddressBuilder();
        builder.AnnouncementBuilder();
        builder.HousingCommunityBuilder();
        builder.UserBuilder();
    }

    private static void AddressBuilder(this ModelBuilder builder)
    {
        var entity = builder.Entity<Address>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.City).HasMaxLength(255).IsRequired();
        entity.Property(q => q.ZipCode).HasMaxLength(10).IsRequired();
        entity.Property(q => q.Street).HasMaxLength(255).IsRequired();
        entity.Property(q => q.HomeNr).HasMaxLength(10).IsRequired();
        entity.Property(q => q.FlatNr).IsRequired(false);
    }

    private static void AnnouncementBuilder(this ModelBuilder builder)
    {
        var entity = builder.Entity<Announcement>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Message).IsRequired();
        entity.Property(q => q.Title).HasMaxLength(100).IsRequired();
        entity.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        entity.HasOne(q => q.HousingCommunity).WithMany(q => q.Announcements).HasForeignKey(q => q.HousingCommunityId);
    }

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
}
