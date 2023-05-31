using Hocomm.Contracts.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.HousingCommunities;

public class AddHousingCommunityRequest
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Required]
    public AddressDto Address { get; set; } = null!;
}

public class GetHousingCommunityParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class HousingCommunityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
}
