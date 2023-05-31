using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public class UserMeter
{
    //UserMeters
    //id, EvidenceItemId?, housingCommunityId, userMeterTypeId, value, createdAt
    public Guid Id { get; set; }
    public double Value { get; set; }
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

    public Guid UserMeterTypeId { get; set; }
    public UserMeterType UserMeterType { get; set; } = null!;
}

public class UserMeterType
{
    //UserMeterTypes
    //id, name, unitType, description
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string UnitType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<UserMeter> UserMeters { get; set; } = null!;
}


internal static class UserMeterModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<UserMeter>();
        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Value).IsRequired();
        entity.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        //ref
        entity.HasOne(q => q.CreatedBy).WithMany(q => q.UserMeters).HasForeignKey(q => q.CreatedById);
        entity.HasOne(q => q.EvidenceItem).WithMany(q => q.UserMeters).HasForeignKey(q => q.EvidenceItemId);
        entity.HasOne(q => q.UserMeterType).WithMany(q => q.UserMeters).HasForeignKey(q => q.UserMeterTypeId);


        var entityUserMeterType = builder.Entity<UserMeterType>();
        entityUserMeterType.HasKey(q => q.Id);
        entityUserMeterType.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityUserMeterType.Property(q => q.Name).HasMaxLength(100).IsRequired();
        entityUserMeterType.Property(q => q.UnitType).HasMaxLength(10).IsRequired();
        entityUserMeterType.Property(q => q.Description).HasMaxLength(1000).IsRequired();
        entityUserMeterType.Property(q => q.ModifiedAt).IsRequired(false);
        entityUserMeterType.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        //ref
        entityUserMeterType.HasOne(q => q.HousingCommunity).WithMany(q => q.UserMeterTypes).HasForeignKey(q => q.HousingCommunityId);
    }
}