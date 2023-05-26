using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Nip { get; set; }


    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;
}

public class CostInvoice
{
    //id, name, invoinceNumber, issuedAt, dueTo, issuedByCompanyId, grossValue, netValue, vatValue, householdCommunityId, createdAt, modifiedAt
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;


    public string InvoinceNumber { get; set; } = null!;
    public DateTime IssuedAt { get; set; }
    public DateTime DueTo { get; set; }

    public double GrossValue { get; set; }
    public double NetValue { get; set; }
    public int VatValue { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public Guid IssuedByCompanyId { get; set; }
    public Company IssuedByCompany { get; set; } = null!;
}



public class CostOther
{
    //id, name, grossValue, housingCommunityId, createdAt, modifiedAt
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;


    public string InvoinceNumber { get; set; } = null!;

    public double GrossValue { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;
}



public enum EvidenceFeeType
{
    Draft = 1,
    Issued = 2,
}

public class EvidenceFee
{
    //id, feeNr, evidenceItemId, paidTo, createdAt, modifiedAt, status(draft, issued)
    public Guid Id { get; set; }
    public string FeeNr { get; set; } = null!;
    public DateTime PaidTo { get; set; }
    public EvidenceFeeType Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }


    // ref
    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

}

public class EvidenceFeeItem
{
    //id, EvidenceFeeId, name, feeValue
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;


    // ref
    public Guid EvidenceFeeId { get; set; }
    public EvidenceFee EvidenceFee { get; set; } = null!;
}
