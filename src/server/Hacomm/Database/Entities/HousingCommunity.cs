using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class HousingCommunity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<Announcement> Announcements { get; set; } = null!;

    public List<User> Users { get; set; } = null!;
    public List<UserMeter> UserMeters { get; set; } = null!;
    public List<UserMeterType> UserMeterTypes { get; set; } = null!;
    public List<Resolution> Resolutions { get; set; } = null!;
    public List<InternalMessage> ToUserInternalMessages { get; set; } = null!;
    public List<InternalMessage> FromUserInternalMessages { get; set; } = null!;
}
