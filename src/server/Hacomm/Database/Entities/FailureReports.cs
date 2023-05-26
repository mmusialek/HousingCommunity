using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class FailureReports
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
}


public class FailureReportAttachements
{
    //FailureReportAttachements
    //id, FailureReportId, name, path
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreatedAt { get; set; }


    // ref
    public Guid FailureReportId { get; set; }
    public User FailureReport { get; set; } = null!;
}


public class FailureReportsComments
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
    public User FailureReport { get; set; } = null!;
}
