using Hocomm.Contracts.Common;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FeeCostInvoice;
public class CreateCompanyDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public int Nip { get; set; }

    public CompanyTypes CompanyType { get; set; }

    [Required]
    public AddressDto Address { get; set; } = null!;
}
