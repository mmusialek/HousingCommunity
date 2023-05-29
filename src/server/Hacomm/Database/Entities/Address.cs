using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class Address
{
    public Guid Id { get; set; }
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string HomeNr { get; set; } = null!;
    public int? FlatNr { get; set; }

    //ref

    public IList<User> Users { get; set; } = null!;
    public IList<HousingCommunity> HousingCommunities { get; set; } = null!;
    public IList<Company> Companies { get; set; } = null!;
}
