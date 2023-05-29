using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class FailureReport
{
    // FailureReports
    // id, title, message, fromUserId, HousingCommunityId, createdAt, finishedAt?,
    // status(new, in progress, solved, rejected)
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }


    // ref
    public Guid FromUserId { get; set; }
    public User FromUser { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<FailureReportAttachement> FailureReportAttachements { get; set; } = null!;
    public IList<FailureReportsComment> FailureReportsComments { get; set; } = null!;
}


public class FailureReportAttachement
{
    //FailureReportAttachements
    //id, FailureReportId, name, path
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreatedAt { get; set; }


    // ref
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public Guid FailureReportId { get; set; }
    public FailureReport FailureReport { get; set; } = null!;
}


public class FailureReportsComment
{
    //FailureReportsComments
    //id, FailureReportId, message, fromUserId
    public Guid Id { get; set; }
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }


    // ref
    public Guid FromUserId { get; set; }
    public User FromUser { get; set; } = null!;

    public Guid FailureReportId { get; set; }
    public FailureReport FailureReport { get; set; } = null!;
}
