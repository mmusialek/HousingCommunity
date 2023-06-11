using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Evidences;
public class CreateEvidenceItemDto
{
    [Required]
    public string Nr { get; set; } = null!;

    [Required]
    [Range(0, int.MaxValue)]
    public int FloorNr { get; set; }

    public string ShortDescription { get; set; } = null!;

    [Required]
    [Range(1, double.MaxValue)]
    public double Area { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int PersonCount { get; set; }

    [Required]
    public Guid HousingCommunityId { get; set; }

    [Required]
    public Guid EvidenceTypeId { get; set; }

    public IList<Guid> OwnerIds { get; set; } = null!;
}

public class AddEvidenceItemUsersDto
{
    [Required]
    public Guid EvidenceItemId { get; set; }

    public IList<Guid> OwnerIds { get; set; } = null!;
}


public class GetEvidenceItemsParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? Page { get; set; }
}

public class EvidenceItemDto
{
    public Guid Id { get; set; }
    public string Nr { get; set; } = null!;
    public int FloorNr { get; set; }
    public string ShortDescription { get; set; } = null!;
    public double Area { get; set; }
    public int PersonCount { get; set; }

    public Guid EvidenceTypeId { get; set; }
}

public class UpdateEvidenceItemDto
{
    [Required]
    public Guid EvidenceItemId { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? FloorNr { get; set; }

    public string ShortDescription { get; set; } = null!;
    
    [Range(1, double.MaxValue)]
    public double? Area { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? PersonCount { get; set; }
}