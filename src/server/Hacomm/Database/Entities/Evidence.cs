using Hacomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public class EvidenceItem
{
    //id, nr, floorNr, shortDescription, area, personCount, evidenceTypeId, createdAt
    public Guid Id { get; set; }
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
}


public class EvidenceTypeItem
{
    //EvidenceTypeItem
    //id, name, shortDescription, housingCommunityId, createdAt

    public Guid Id { get; set; }
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

public class EvidenceItemMembers
{
    //EvidenceItemMembers
    //id, EvidenceItemId, ownerUserId?, housingCommunityId, parentEvidenceItemId?, createdAt x
    public Guid Id { get; set; }


    // ref
    public Guid OwnedByUserId { get; set; }
    public User OwnedByUser { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid EvidenceItemId { get; set; }
    public EvidenceItem EvidenceItem { get; set; } = null!;

    public Guid? ParentEvidenceItemId { get; set; }
    public EvidenceItem? ParentEvidenceItem { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;
}

