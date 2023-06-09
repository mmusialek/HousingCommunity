using Hocomm.Contracts.Common;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class AddressService : ServiceBase
{
    public AddressService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddressDto dto)
    {
        var entity = ToEntity(dto);
        AddAndSave(entity);
        return entity.Id;
    }

    public static Address ToEntity(AddressDto dto)
    {
        Address res = new();
        res.City = dto.City;
        res.ZipCode = dto.ZipCode;
        res.Street = dto.Street;
        res.HomeNr = dto.HomeNr;
        res.FlatNr = dto.FlatNr;

        return res;
    }
}
