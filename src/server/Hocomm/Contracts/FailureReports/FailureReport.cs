using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FailureReports;
public class CreateFailureReportDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class GetFailureReportParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? Page { get; set; }
}

public class FailureReportDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;
    public FailureReportStatus Status { get; set; }

    public Guid CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class FailureReportDetailsDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;
    public FailureReportStatus Status { get; set; }

    public IList<FailureReportCommentDto> Comments { get; set; } = null!;
}

public class FailureReportCommentDto
{
    public Guid Id { get; set; }

    public string Message { get; set; } = null!;
    public Guid FromUserId { get; set; }
}

public class AddFailureReportCommentDto
{
    [Required]
    public string Message { get; set; } = null!;

    [Required]
    public Guid FailureReportId { get; set; }
}

public class ChangeFailureReportStatusDto
{
    [Required]
    public Guid FailureReportId { get; set; }

    [Required]
    public FailureReportStatus Status { get; set; }
}