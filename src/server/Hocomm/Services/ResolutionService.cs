using Hocomm.Contracts.Resolutions;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hocomm.Services;
public class ResolutionService : ServiceBase
{
    public ResolutionService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddResolutionDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        return AddAndSave(entity);
    }

    public IList<ResolutionDto> Get(GetResolutionParams dto)
    {
        var entity = _context.Resolutions.Where(q => q.HousingCommunityId == dto.HousingCommunityId).GetPage(dto.PageDto).ToList();
        var res = ToDto(entity);

        return res;
    }

    public Guid Vote(VoteResolutionDto dto)
    {
        var entity = _context.Resolutions.Single(q => q.Id == dto.ResolutionId);

        if (entity.Status != ResolutionStatusType.Finished)
        {
            throw new HttpException(HttpStatusCode.BadRequest, "Resolution should be finished.");
        }

        ResolutionVote vote = new();
        vote.ResolutionId = entity.Id;
        vote.AuthorId = _metadata.UserId;
        vote.Type = dto.Vote;

        return AddAndSave(vote);
    }

    public Guid Update(UpdateResolutionDto dto)
    {
        var entity = _context.Resolutions.Single(q => q.Id == dto.ResolutionId);

        if (entity.Status == ResolutionStatusType.Finished)
        {
            throw new HttpException(HttpStatusCode.BadRequest, "Resolution should NOT be finished.");
        }

        entity.Title = dto.Title;
        entity.Message = dto.Message;

        _context.SaveChanges();
        return entity.Id;
    }

    private static Resolution ToEntity(AddResolutionDto dto, ServiceMetadata metadata)
    {
        Resolution res = new();
        res.Title = dto.Title;
        res.Message = dto.Message;
        res.HousingCommunityId = dto.HousingCommunityId;
        res.CreatedById = metadata.UserId;

        return res;
    }

    public static IList<ResolutionDto> ToDto(IList<Resolution> entities)
    {
        List<ResolutionDto> res = new();

        foreach (var entity in entities)
        {
            ResolutionDto item = new();
            item.Title = entity.Title;
            item.Message = entity.Message;
            item.Status = entity.Status;

            res.Add(item);
        }

        return res;
    }

}
