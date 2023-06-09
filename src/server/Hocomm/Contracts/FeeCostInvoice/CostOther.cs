using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FeeCostInvoice;
public class AddCostOtherDto
{
    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string InvoinceNumber { get; set; } = null!;

    [Required]
    public double GrossValue { get; set; }

    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class UpdateCostOtherDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string InvoinceNumber { get; set; } = null!;

    [Required]
    public double GrossValue { get; set; }
}
