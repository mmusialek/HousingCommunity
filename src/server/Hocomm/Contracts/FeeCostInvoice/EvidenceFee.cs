using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FeeCostInvoice;
public class AddEvidenceFeeDto
{
    [Required]
    public string FeeNr { get; set; } = null!;

    [Required]
    public DateTime PaidTo { get; set; }

    [Required]
    public EvidenceFeeType Status { get; set; }

    [Required]
    public Guid EvidenceItemId { get; set; }

    [Required]
    public IList<EvidenceFeeItemDto> EvidenceFeeItems { get; set; } = null!;
}

public class EvidenceFeeItemDto
{
    public Guid? Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public double GrossValue { get; set; }
}

public class UpdateEvidenceFeeDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string FeeNr { get; set; } = null!;

    [Required]
    public DateTime PaidTo { get; set; }

    [Required]
    public EvidenceFeeType Status { get; set; }

    [Required]
    public Guid EvidenceItemId { get; set; }

    [Required]
    public IList<EvidenceFeeItemDto> EvidenceFeeItems { get; set; } = null!;
}