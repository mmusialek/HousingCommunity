using Hacomm.Contracts.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Contracts.HousingCommunities;

public class AddHousingCommunityRequest
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Required]
    public AddressDto Address { get; set; } = null!;
}

public class HousingCommunityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
}