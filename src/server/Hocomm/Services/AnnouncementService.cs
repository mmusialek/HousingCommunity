using Hocomm.Contracts.Announcements;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm;
using Hocomm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hocomm.Contracts;

namespace Hocomm.Services;
public class AnnouncementService : ServiceBase
{
    public AnnouncementService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddAnnouncementRequest request)
    {
        var entity = new Announcement();
        entity.Title = request.Title;
        entity.Message = request.Message;
        entity.AuthorId = _metadata.UserId;
        entity.ValidTo = request.ValidTo;
        entity.HousingCommunityId = request.HousingCommunityId;

        return AddAndSave(entity);
    }

    public IEnumerable<AnnouncementDto> Get(GetAnnouncementParams query)
    {
        var data = _context.Announcements.Where(q => q.ValidTo < DateTime.UtcNow).GetPage(query.PageDto).ToList();
        var res = data.Select(ToDto);

        return res;
    }

    public async Task UpdateAsync(UpdateAnnouncementRequest request)
    {
        var item = _context.Announcements.Single(q => q.Id == request.Id && q.AuthorId == _metadata.UserId);
        item.Title = request.Title;
        item.Message = request.Message;

        await _context.SaveChangesAsync();
    }

    private AnnouncementDto ToDto(Announcement entity)
    {
        AnnouncementDto res = new();
        res.Id = entity.Id;
        res.Title = entity.Title;
        res.Message = entity.Message;
        res.AuthorId = entity.AuthorId;
        res.CreatedAt = entity.CreatedAt;

        return res;
    }
}
