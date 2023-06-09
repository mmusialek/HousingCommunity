using Hocomm.Contracts;
using Hocomm.Contracts.UserMeters;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Hocomm.Services;
public class UserMeterService : ServiceBase
{
    public UserMeterService(PgSqlContext context) : base(context)
    {
    }

    public IReadOnlyList<UserMeterDto> Get(GetUserMeterParams query)
    {
        var (page, skip) = query.PageDto.GetPage();

        var list = _context.UserMeters.Where(q => q.EvidenceItem.HousingCommunityId == query.HousingCommunityId).Skip(skip).Take(page);
        var res = list.Select(ToDto).ToList();
        return res;
    }

    public async Task<Guid> AddAsync(AddUserMeterRequest request)
    {
        UserMeter entity = new()
        {
            Value = request.MeterValue,
            UserMeterTypeId = request.UserMeterTypeId,
            CreatedById = _metadata.UserId
        };

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
