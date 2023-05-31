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
    private readonly PgSqlContext _context;

    public AnnouncementService(PgSqlContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AddAnnouncementRequest request)
    {
        var user = _context.Users.First(q => q.Id == _metadata.UserId);

        var entity = new Announcement();
        entity.Title = request.Title;
        entity.Message = request.Message;
        entity.AuthorId = _metadata.UserId;
        entity.ValidTo = request.ValidTo;

        entity.HousingCommunityId = request.HousingCommunityId;

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<AnnouncementDto> Get(GetAnnouncementParams query)
    {
        var (page, skip) = query.PageDto.GetPage();

        var data = _context.Announcements.Where(q => q.ValidTo < DateTime.UtcNow).Skip(skip).Take(page).ToList();
        var res = data.Select(ToDto);

        return res;
    }

    public async Task UpdateAsync(UpdateAnnouncementRequest request)
    {
        var item = _context.Announcements.First(q => q.Id == request.Id && q.AuthorId == _metadata.UserId);
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
