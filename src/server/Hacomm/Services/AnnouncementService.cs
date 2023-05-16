﻿using Hacomm.Contracts.Announcements;
using Hacomm.Database;
using Hacomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Services;
public class AnnouncementService
{
    private readonly PgSqlContext _context;

    public AnnouncementService(PgSqlContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AddAnnouncementRequest request)
    {
        var entity = new Announcement();
        entity.Title = request.Title;
        entity.Message = request.Message;
        entity.AuthorId = request.AuthorId;
        entity.ValidTo = request.ValidTo;

        entity.HousingCommunityId = Guid.Empty;

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<AnnouncementDto> Get(GetAnnouncementParams query)
    {
        var data = _context.Announcements.Where(q => q.ValidTo < DateTime.UtcNow).ToList();
        var res = data.Select(ToDto);

        return res;
    }

    public async Task UpdateAsync(UpdateAnnouncementRequest request)
    {
        var item = _context.Announcements.First(q => q.Id == request.Id && q.AuthorId == request.AuthorId);
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
