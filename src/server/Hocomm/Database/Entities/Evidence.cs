using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public class EvidenceItem : BaseEntity
{
    //id, nr, floorNr, shortDescription, area, personCount, evidenceTypeId, createdAt
    public string Nr { get; set; } = null!;
    public int FloorNr { get; set; }
    public string ShortDescription { get; set; } = null!;
    public double Area { get; set; }
    public int PersonCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;


    // ref lists

    public IList<EvidenceItemMember> EvidenceItemMembers { get; set; } = null!;
    public IList<EvidenceItemMember> ParentEvidenceItemMembers { get; set; } = null!;
    public IList<CalendarEvent> CalendarEvents { get; set; } = null!;
    public IList<UserMeter> UserMeters { get; set; } = null!;
    public IList<UserMeterType> UserMeterTypes { get; set; } = null!;
    public IList<EvidenceFee> EvidenceFees { get; set; } = null!;
}


public class EvidenceType : BaseEntity
{
    //EvidenceTypeItem
    //id, name, shortDescription, housingCommunityId, createdAt
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;
}

public class EvidenceItemMember : BaseEntity
{
    //EvidenceItemMembers
    //id, EvidenceItemId, ownerUserId?, housingCommunityId, parentEvidenceItemId?, createdAt

    // ref
    public Guid OwnedByUserId { get; set; }
    public User OwnedByUser { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

    public Guid? ParentEvidenceItemId { get; set; }
    public EvidenceItem? ParentEvidenceItem { get; set; } = null!;
}

internal static class EvidenceItemModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var evidenceItem = builder.Entity<EvidenceItem>();
        evidenceItem.HasKey(q => q.Id);
        evidenceItem.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        evidenceItem.Property(q => q.Nr).IsRequired();
        evidenceItem.Property(q => q.FloorNr).IsRequired();
        evidenceItem.Property(q => q.ShortDescription).IsRequired();
        evidenceItem.Property(q => q.Area).IsRequired();
        evidenceItem.Property(q => q.PersonCount).IsRequired();
        evidenceItem.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        evidenceItem.Property(q => q.ModifiedAt).IsRequired(false);


        // ref
        evidenceItem.HasOne(q => q.CreatedByUser).WithMany(q => q.EvidenceItems).HasForeignKey(q => q.CreatedByUserId);
        evidenceItem.HasOne(q => q.HousingCommunity).WithMany(q => q.EvidenceItems).HasForeignKey(q => q.HousingCommunityId);


        var evidenceTypeItem = builder.Entity<EvidenceType>();
        evidenceTypeItem.HasKey(q => q.Id);
        evidenceTypeItem.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        evidenceTypeItem.Property(q => q.Name).HasMaxLength(100).IsRequired();
        evidenceTypeItem.Property(q => q.ShortDescription).HasMaxLength(500).IsRequired();
        evidenceTypeItem.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        evidenceTypeItem.Property(q => q.ModifiedAt).IsRequired(false);

        evidenceTypeItem.HasOne(q => q.CreatedByUser).WithMany(q => q.EvidenceTypeItems).HasForeignKey(q => q.CreatedByUserId);
        evidenceTypeItem.HasOne(q => q.HousingCommunity).WithMany(q => q.EvidenceTypeItems).HasForeignKey(q => q.HousingCommunityId);


        var evidenceItemMember = builder.Entity<EvidenceItemMember>();
        evidenceTypeItem.HasKey(q => q.Id);
        evidenceTypeItem.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        //refs
        evidenceItemMember.HasOne(q => q.OwnedByUser).WithMany(q => q.EvidenceItemMemberOwnedByUser).HasForeignKey(q => q.OwnedByUserId);
        evidenceItemMember.HasOne(q => q.CreatedByUser).WithMany(q => q.EvidenceItemMemberCreatedBy).HasForeignKey(q => q.CreatedByUserId);
        evidenceItemMember.HasOne(q => q.EvidenceItem).WithMany(q => q.EvidenceItemMembers).HasForeignKey(q => q.EvidenceItemId);
        evidenceItemMember.HasOne(q => q.ParentEvidenceItem).WithMany(q => q.ParentEvidenceItemMembers).HasForeignKey(q => q.ParentEvidenceItemId);
    }
}
