using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public enum CompanyTypes
{
    None = 0,
    HousingCommunity = 1,
    Company = 2,
}


public enum EvidenceFeeType
{
    None = 0,
    Draft = 1,
    Issued = 2,
}

public class Company : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Nip { get; set; }
    public CompanyTypes CompanyType { get; set; }



    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    // ref lists
    public IList<CostInvoice> CostInvoices { get; set; } = null!;
}

public class CostInvoice : BaseEntity, IDateEntity
{
    //id, name, invoinceNumber, issuedAt, dueTo, issuedByCompanyId, grossValue, netValue, vatValue, householdCommunityId, createdAt, modifiedAt
    public string Name { get; set; } = null!;
    public string InvoinceNumber { get; set; } = null!;
    public DateTime IssuedAt { get; set; }
    public DateTime DueTo { get; set; }

    public double GrossValue { get; set; }
    public double NetValue { get; set; }
    public int VatValue { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public Guid ModifiedById { get; set; }
    public User ModifiedBy { get; set; } = null!;

    // ref

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public Guid IssuedByCompanyId { get; set; }
    public Company IssuedByCompany { get; set; } = null!;
}



public class CostOther : BaseEntity, IDateEntity
{
    //id, name, grossValue, housingCommunityId, createdAt, modifiedAt
    public string Name { get; set; } = null!;
    public string InvoinceNumber { get; set; } = null!;
    public double GrossValue { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public Guid ModifiedById { get; set; }
    public User ModifiedBy { get; set; } = null!;

    // ref
    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;
}


public class EvidenceFee : BaseEntity, IDateEntity
{
    //id, feeNr, evidenceItemId, paidTo, createdAt, modifiedAt, status(draft, issued)
    public string FeeNr { get; set; } = null!;
    public DateTime PaidTo { get; set; }
    public EvidenceFeeType Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public Guid ModifiedById { get; set; }
    public User ModifiedBy { get; set; } = null!;


    // ref
    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

    public IList<EvidenceFeeItem> EvidenceFeeItems { get; set; } = null!;
}

public class EvidenceFeeItem : BaseEntity
{
    //id, EvidenceFeeId, name, feeValue
    public string Name { get; set; } = null!;
    public double GrossValue { get; set; }


    // ref
    public Guid EvidenceFeeId { get; set; }
    public EvidenceFee EvidenceFee { get; set; } = null!;
}

internal static class FeeCostsInvoicesModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<Company>();
        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Name).HasMaxLength(100).IsRequired();
        entity.Property(q => q.Nip).IsRequired();
        entity.Property(q => q.CompanyType).IsRequired();

        //ref
        entity.HasOne(q => q.Address).WithMany(q => q.Companies).HasForeignKey(q => q.AddressId);



        var entityCostInvoice = builder.Entity<CostInvoice>();
        entityCostInvoice.HasKey(q => q.Id);
        entityCostInvoice.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityCostInvoice.Property(q => q.Name).HasMaxLength(100).IsRequired();
        entityCostInvoice.Property(q => q.InvoinceNumber).HasMaxLength(100).IsRequired();
        entityCostInvoice.Property(q => q.IssuedAt).IsRequired();
        entityCostInvoice.Property(q => q.DueTo).IsRequired();

        entityCostInvoice.Property(q => q.GrossValue).IsRequired();
        entityCostInvoice.Property(q => q.NetValue).IsRequired();
        entityCostInvoice.Property(q => q.VatValue).IsRequired();

        entityCostInvoice.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        entityCostInvoice.Property(q => q.ModifiedAt).IsRequired(false);


        // ref
        entityCostInvoice.HasOne(q => q.HousingCommunity).WithMany(q => q.CostInvoices).HasForeignKey(q => q.HousingCommunityId);
        entityCostInvoice.HasOne(q => q.IssuedByCompany).WithMany(q => q.CostInvoices).HasForeignKey(q => q.IssuedByCompanyId);

        entityCostInvoice.HasOne(q => q.CreatedBy).WithMany(q => q.CreatedByCostInvoices).HasForeignKey(q => q.CreatedById);
        entityCostInvoice.HasOne(q => q.ModifiedBy).WithMany(q => q.ModifiedByCostInvoices).HasForeignKey(q => q.ModifiedById);

        // CostOther
        var entityCostOther = builder.Entity<CostOther>();
        entityCostOther.HasKey(q => q.Id);
        entityCostOther.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityCostOther.Property(q => q.Name).HasMaxLength(100).IsRequired();
        entityCostOther.Property(q => q.InvoinceNumber).HasMaxLength(100).IsRequired();
        entityCostOther.Property(q => q.GrossValue).IsRequired();
        entityCostOther.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        entityCostOther.Property(q => q.ModifiedAt).IsRequired(false);

        // ref
        entityCostOther.HasOne(q => q.HousingCommunity).WithMany(q => q.CostOthers).HasForeignKey(q => q.HousingCommunityId);
        entityCostOther.HasOne(q => q.CreatedBy).WithMany(q => q.CreatedByCostOthers).HasForeignKey(q => q.CreatedById);
        entityCostOther.HasOne(q => q.ModifiedBy).WithMany(q => q.ModifiedByCostOthers).HasForeignKey(q => q.ModifiedById);



        var entityEvidenceFee = builder.Entity<EvidenceFee>();
        entityEvidenceFee.HasKey(q => q.Id);
        entityEvidenceFee.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityEvidenceFee.Property(q => q.FeeNr).HasMaxLength(100).IsRequired();
        entityEvidenceFee.Property(q => q.PaidTo).IsRequired();
        entityEvidenceFee.Property(q => q.Status).IsRequired();
        entityEvidenceFee.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        entityEvidenceFee.Property(q => q.ModifiedAt).IsRequired(false);

        // ref
        entityEvidenceFee.HasOne(q => q.EvidenceItem).WithMany(q => q.EvidenceFees).HasForeignKey(q => q.EvidenceItemId);
        entityEvidenceFee.HasOne(q => q.CreatedBy).WithMany(q => q.CreatedByEvidenceFees).HasForeignKey(q => q.CreatedById);
        entityEvidenceFee.HasOne(q => q.ModifiedBy).WithMany(q => q.ModifiedByEvidenceFees).HasForeignKey(q => q.ModifiedById);


        var entityEvidenceFeeItem = builder.Entity<EvidenceFeeItem>();
        entityEvidenceFeeItem.HasKey(q => q.Id);
        entityEvidenceFeeItem.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityEvidenceFeeItem.Property(q => q.Name).HasMaxLength(100).IsRequired();


        // ref
        entityEvidenceFeeItem.HasOne(q => q.EvidenceFee).WithMany(q => q.EvidenceFeeItems).HasForeignKey(q => q.EvidenceFeeId);
    }
}
