using Hocomm.Contracts.UserMeters;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class UserMeterTypeService : ServiceBase
{
    public UserMeterTypeService(PgSqlContext context) : base(context)
    {
    }

    public async Task<Guid> AddAsync(AddUserMeterTypeRequest dto)
    {
        UserMeterType entity = new();
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.HousingCommunityId = dto.HousingCommunityId;

        // TODO check if user belongs to given HC

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public IReadOnlyList<UserMeterTypeDto> Get(GetUserMeterTypeParams query)
    {
        var list = _context.UserMeterTypes.Where(q => q.HousingCommunityId == query.HousingCommunityId);
        var res = list.Select(ToDto).ToList();
        return res;
    }

    private UserMeterTypeDto ToDto(UserMeterType entity)
    {
        UserMeterTypeDto res = new();
        res.Id = entity.Id;
        res.Name = entity.Name;
        res.Description = entity.Description;

        return res;
    }
}
