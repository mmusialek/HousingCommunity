using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database.Entities;
public class HousingCommunity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<Announcement> Announcements { get; set; } = null!;

    public List<User> Users { get; set; } = null!;
}
