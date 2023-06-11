using Hocomm.Contracts.FailureReports;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm.Models;
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

    public FailureReportDetailsDto GetDetails(Guid id)
    {
        var hocomm = _context.HousingCommunities.Where(q => q.Users.Equals(_metadata.UserId)).Select(q => q.Id).ToList()
            ?? throw new HttpException(System.Net.HttpStatusCode.BadRequest, "Wrong Report id");

        var failureReport = _context.FailureReports.Single(q => q.Id == id && hocomm.Contains(q.HousingCommunityId));
        var res = ToDetailsDto(failureReport);

        return res;
    }

    public IList<FailureReportDto> Get(GetFailureReportParams query)
    {
        var entities = _context.FailureReports.Where(q => q.HousingCommunityId == query.HousingCommunityId).GetPage(query.Page);
        var res = entities.Select(ToDto).ToList();
        return res;
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
        var failureRepost = _context.FailureReports.Single(q => q.Id == dto.FailureReportId);
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
        res.CreatedByUserId = metadata.UserId;

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

    public static FailureReportDetailsDto ToDetailsDto(FailureReport entity)
    {
        FailureReportDetailsDto res = new();
        res.Id = entity.Id;
        res.Title = entity.Title;
        res.Message = entity.Message;
        res.Status = entity.Status;

        res.Comments = new List<FailureReportCommentDto>();
        foreach (var entityComm in entity.FailureReportsComments)
        {
            FailureReportCommentDto tmp = new();
            tmp.Id = entityComm.Id;
            tmp.Message = entityComm.Message;
            tmp.FromUserId = entityComm.FromUserId;

            res.Comments.Add(tmp);
        }

        return res;
    }

    public static FailureReportDto ToDto(FailureReport entity)
    {
        FailureReportDto res = new();
        res.Id = entity.Id;
        res.Title = entity.Title;
        res.Message = entity.Message;
        res.Status = entity.Status;

        res.CreatedAt = entity.CreatedAt;
        res.CreatedByUserId = entity.CreatedByUserId;

        return res;
    }
}
