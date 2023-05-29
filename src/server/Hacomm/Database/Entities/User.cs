using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;


    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<HousingCommunity> HousingCommunities { get; set; } = null!;
    public List<UserMeter> UserMeters { get; set; } = null!;

    public IList<ResolutionVote> ResolutionVotes { get; set; } = null!;
    public IList<Resolution> Resolutions { get; set; } = null!;
    public IList<InternalMessage> InternalMessages { get; set; } = null!;

}
