using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FeeCostInvoice;
public class AddCostInvoiceDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string InvoinceNumber { get; set; } = null!;

    [Required]
    public DateTime IssuedAt { get; set; }

    [Required]
    public DateTime DueTo { get; set; }

    [Required]
    public double GrossValue { get; set; }

    [Required]
    public double NetValue { get; set; }

    [Required]
    [Range(0, 100)]
    public int VatValue { get; set; }

    [Required]
    public Guid HousingCommunityId { get; set; }

    [Required]
    public Guid IssuedByCompanyId { get; set; }
}

public class UpdateCostInvoiceDto
{
    [Required]
    public Guid Id { get; set; } 
    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string InvoinceNumber { get; set; } = null!;

    [Required]
    public DateTime IssuedAt { get; set; }

    [Required]
    public DateTime DueTo { get; set; }

    [Required]
    public double GrossValue { get; set; }

    [Required]
    public double NetValue { get; set; }

    [Required]
    [Range(0, 100)]
    public int VatValue { get; set; }

    [Required]
    public Guid IssuedByCompanyId { get; set; }
}
