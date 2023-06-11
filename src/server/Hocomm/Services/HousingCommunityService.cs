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

    public Guid Add(AddHousingCommunityRequest request)
    {
        var address = AddressService.ToEntity(request.Address);

        HousingCommunity entity = new();
        entity.Name = request.Name;
        entity.Address = address;

        AddAndSave(entity);
        return entity.Id;
    }

    public HousingCommunityDto Get(GetHousingCommunityParams query)
    {
        var entity = _context.HousingCommunities.Single(q => q.Id.Equals(query.HousingCommunityId));
        return ToDto(entity);
    }

    private static HousingCommunityDto ToDto(HousingCommunity entity)
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
