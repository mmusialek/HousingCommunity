using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Resolutions;
public class AddResolutionDto
{
    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }

    [Required]
    public ResolutionStatusType Status { get; set; }
}

public class GetResolutionParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? PageDto { get; set; }
}

public class ResolutionDto
{
    public Guid ResolutionId { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public ResolutionStatusType Status { get; set; }

    public int YesVotes { get; set; }
    public int NoVotes { get; set; }
}

public class VoteResolutionDto
{
    [Required]
    public Guid ResolutionId { get; set; }

    [Required]
    public ResolutionVotesType Vote { get; set; }
}

public class UpdateResolutionDto
{
    [Required]
    public Guid ResolutionId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    [Required]
    public ResolutionStatusType Status { get; set; }
}