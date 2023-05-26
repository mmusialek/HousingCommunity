using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class UserMeter
{
    public Guid Id { get; set; }
    public long Value { get; set; }
    public DateTime CreatedAt { get; set; }

    // refs
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public Guid UserMeterTypeId { get; set; }
    public UserMeterType UserMeterType { get; set; } = null!;
}
