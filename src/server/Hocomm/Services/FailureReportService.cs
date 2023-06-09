using Hocomm.Contracts.FailureReports;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class FailureReportService : ServiceBase
{
    public FailureReportService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(CreateFailureReportDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        AddAndSave(entity);

        return entity.Id;
    }

    public Guid AddComment(AddFailureReportCommentDto dto)
    {
        // TODO add comments can only author of the failure and privileged user (admin, hc owner, etc)
        var entity = ToEntity(dto, _metadata);
        _context.Add(entity);

        return entity.Id;
    }

    public Guid ChangeStatus(ChangeFailureReportStatusDto dto)
    {
        var failureRepost = _context.FailureReports.First(q => q.Id == dto.FailureReportId);
        // TODO check is woner or admin, hc owner, etc

        if (failureRepost.Status == FailureReportStatus.Solved || failureRepost.Status == FailureReportStatus.Rejected)
        {
            throw new Exception("Cannot change closed report");
        }

        if (dto.Status == FailureReportStatus.Solved || dto.Status == FailureReportStatus.Rejected)
        {
            failureRepost.FinishedAt = DateTime.UtcNow;
        }

        failureRepost.Status = dto.Status;
        _context.SaveChanges();

        return dto.FailureReportId;
    }

    public static FailureReport ToEntity(CreateFailureReportDto dto, ServiceMetadata metadata)
    {
        FailureReport res = new();
        res.Title = dto.Title;
        res.Message = dto.Message;
        res.HousingCommunityId = dto.HousingCommunityId;
        res.FromUserId = metadata.UserId;

        return res;
    }

    public static FailureReportComment ToEntity(AddFailureReportCommentDto dto, ServiceMetadata metadata)
    {
        FailureReportComment res = new();
        res.Message = dto.Message;
        res.FailureReportId = dto.FailureReportId;
        res.FromUserId = metadata.UserId;

        return res;
    }
}
