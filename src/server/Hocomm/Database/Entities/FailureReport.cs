using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;

public enum FailureReportStatus
{
    None = 0,
    InProgress = 1,
    Solved = 2,
    Rejected = 4
}

public class FailureReport : BaseEntity
{
    // FailureReports
    // id, title, message, fromUserId, HousingCommunityId, createdAt, finishedAt?,
    // status(new, in progress, solved, rejected)
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public FailureReportStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }


    // ref
    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<FailureReportAttachement> FailureReportAttachements { get; set; } = null!;
    public IList<FailureReportComment> FailureReportsComments { get; set; } = null!;
}


public class FailureReportAttachement : BaseEntity
{
    //FailureReportAttachements
    //id, FailureReportId, name, path
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreatedAt { get; set; }


    // ref
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public Guid FailureReportId { get; set; }
    public FailureReport FailureReport { get; set; } = null!;
}


public class FailureReportComment
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


internal static class FailureReportModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var failureReport = builder.Entity<FailureReport>();
        failureReport.HasKey(q => q.Id);
        failureReport.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        //FailureReport

        failureReport.Property(q => q.Title).HasMaxLength(100).IsRequired();
        failureReport.Property(q => q.Message).IsRequired();
        failureReport.Property(q => q.Status).IsRequired();
        failureReport.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");
        failureReport.Property(q => q.FinishedAt).IsRequired(false);

        // ref
        failureReport.HasOne(q => q.CreatedByUser).WithMany(q => q.FailureReports).HasForeignKey(q => q.CreatedByUserId);
        failureReport.HasOne(q => q.HousingCommunity).WithMany(q => q.FailureReports).HasForeignKey(q => q.HousingCommunityId);


        var failureReportAttachement = builder.Entity<FailureReportAttachement>();
        failureReportAttachement.HasKey(q => q.Id);
        failureReportAttachement.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        failureReportAttachement.Property(q => q.Name).HasMaxLength(100).IsRequired();
        failureReportAttachement.Property(q => q.Path).HasMaxLength(500).IsRequired();
        failureReportAttachement.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        // ref
        failureReportAttachement.HasOne(q => q.CreatedBy).WithMany(q => q.FailureReportAttachements).HasForeignKey(q => q.CreatedById);
        failureReportAttachement.HasOne(q => q.FailureReport).WithMany(q => q.FailureReportAttachements).HasForeignKey(q => q.FailureReportId);


        var failureReportsComment = builder.Entity<FailureReportComment>();
        failureReportsComment.HasKey(q => q.Id);
        failureReportsComment.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        failureReportsComment.Property(q => q.Message).HasMaxLength(500).IsRequired();
        failureReportsComment.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        // ref
        failureReportsComment.HasOne(q => q.FromUser).WithMany(q => q.FailureReportsComments).HasForeignKey(q => q.FromUserId);
        failureReportsComment.HasOne(q => q.FailureReport).WithMany(q => q.FailureReportsComments).HasForeignKey(q => q.FailureReportId);
    }
}
