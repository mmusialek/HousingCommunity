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

    public Guid AddNew(AddressDto dto)
    {
        var entity = ToEntity(dto);
        _context.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public static Address ToEntity(AddressDto dto)
    {
        Address res = new();
        res.City = dto.City;
        res.Street = dto.Street;
        res.HomeNr = dto.HomeNr;
        res.FlatNr = dto.FlatNr;

        return res;
    }

}
