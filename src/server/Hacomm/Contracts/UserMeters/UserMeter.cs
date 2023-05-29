using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.UserMeters;
public class AddUserMeterRequest
{
    [Required]
    [Range(0, long.MaxValue)]
    public long MeterValue { get; set; }

    [Required]
    public Guid EvidenceItemId { get; set; }

    [Required]
    public Guid UserMeterTypeId { get; set; }
}

public class GetUserMeterParams
{
    [Required]
    public Guid UserMeterTypeId { get; set; }

    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? PageDto { get; set; }
}

public class UserMeterDto
{
    public Guid Id { get; set; }
    public double MeterValue { get; set; }    
    public DateTime CreatedAt { get; set; }
    public Guid UserMeterTypeId { get; set; }
}
