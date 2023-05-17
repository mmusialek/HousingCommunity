using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Contracts.UserMeters;

public class AddUserMeterTypeRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class GetUserMeterTypeParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }
}


public class UserMeterTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
