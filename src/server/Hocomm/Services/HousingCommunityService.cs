using Hocomm.Contracts.Announcements;
using Hocomm.Contracts.Common;
using Hocomm.Contracts.HousingCommunities;
using Hocomm.Database;
using Hocomm.Database.Entities;
using Hocomm.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class HousingCommunityService : ServiceBase
{
    public HousingCommunityService(PgSqlContext context) : base(context)
    {
    }

    public async Task<Guid> AddAsync(AddHousingCommunityRequest request)
    {
        HousingCommunity entity = new();
        entity.Name = request.Name;
        entity.Address = new Address();
        entity.Address.City = request.Address.City;
        entity.Address.ZipCode = request.Address.ZipCode;
        entity.Address.Street = request.Address.Street;
        entity.Address.HomeNr = request.Address.HomeNr;
        entity.Address.FlatNr = request.Address.FlatNr;

        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public HousingCommunityDto Get(GetHousingCommunityParams query)
    {
        var entity = _context.HousingCommunities.First(q => q.Id.Equals(query.HousingCommunityId));
        return ToDto(entity);
    }

    private HousingCommunityDto ToDto(HousingCommunity entity)
    {
        HousingCommunityDto dto = new();
        dto.Name = entity.Name;
        dto.Address = new AddressDto();
        dto.Address.City = entity.Address.City;
        dto.Address.ZipCode = entity.Address.ZipCode;
        dto.Address.Street = entity.Address.Street;
        dto.Address.HomeNr = entity.Address.HomeNr;
        dto.Address.FlatNr = entity.Address.FlatNr;

        return dto;
    }
}
