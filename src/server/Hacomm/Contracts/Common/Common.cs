using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Common;
public class AddressDto
{
    public Guid? Id { get; set; }

    [Required]
    [StringLength(255)]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string ZipCode { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Street { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string HomeNr { get; set; } = null!;

    [Range(1, 999999)]
    public int? FlatNr { get; set; }
}
