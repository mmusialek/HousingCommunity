using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Evidences;
public class CreateEvidenceTypeDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string ShortDescription { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class GetEvidenceTypeParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? Page { get; set; }
}

public class EvidenceTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
}

public class UpdateEvidenceTypeDto
{
    [Required]
    public Guid EventTypeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string ShortDescription { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }
}
