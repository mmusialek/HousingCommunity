using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database.Entities;
public class UserMeterType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string UnitType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    // refs
    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public Guid UserMeterId { get; set; }
    public List<UserMeter> UserMeters { get; set; } = null!;
}
