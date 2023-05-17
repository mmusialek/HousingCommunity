using Hacomm.Contracts;
using Hacomm.Contracts.UserMeters;
using Hacomm.Database;
using Hacomm.Database.Entities;
using Hocomm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Hacomm.Services;
public class UserMeterService : ServiceBase
{
    private readonly PgSqlContext _context;

    public UserMeterService(PgSqlContext context)
    {
        _context = context;
    }

    public IReadOnlyList<UserMeterDto> Get(GetUserMeterParams query)
    {
        var page = query.PageDto ?? new PageDto { Page = 1, Size = 10 };

        var skip = page.Page * page.Size;
        var take = page.Size;
        var list = _context.UserMeters.Where(q => q.HousingCommunityId == query.HousingCommunityId).Skip(skip).Take(take);
        var res = list.Select(ToDto).ToList();
        return res;
    }

    public async Task<Guid> AddEntryAsync(AddUserMeterRequest request)
    {
        UserMeter entity = new();
        entity.Value = request.MeterValue;
        entity.UserMeterTypeId = request.UserMeterTypeId;
        entity.HousingCommunityId = request.HousingCommunityId;
        entity.UserId = _metadata.UserId;

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    private UserMeterDto ToDto(UserMeter entity)
    {
        UserMeterDto res = new();
        res.Id = entity.Id;
        res.MeterValue = entity.Value;
        res.CreatedAt = entity.CreatedAt;

        return res;
    }
}
