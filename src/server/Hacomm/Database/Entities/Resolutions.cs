using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class Resolution
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<ResolutionVote> ResolutionVotes { get; set; } = null!;
}


public enum ResolutionVotesType
{
    None = 0,
    Yes = 1,
    No = 2
}

public class ResolutionVote
{
    public Guid Id { get; set; }
    public ResolutionVotesType Type { get; set; }
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public Guid ResolutionId { get; set; }
    public Resolution Resolution { get; set; } = null!;
}
