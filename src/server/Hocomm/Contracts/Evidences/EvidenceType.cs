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
