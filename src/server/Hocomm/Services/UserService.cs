using Hocomm.Contracts.Users;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class UserService : ServiceBase
{
    private AddressService _addressService;
    public UserService(PgSqlContext context, AddressService addressService) : base(context)
    {
        _addressService = addressService;
    }

    public Guid CreateProfile(CreateUserProfileDto dto)
    {
        var addressId = _addressService.AddNew(dto.Address);
        var userEntity = ToUserEntity(dto, addressId);
        _context.Add(userEntity);
        _context.SaveChanges();

        return dto.Id;
    }


    public static User ToUserEntity(CreateUserProfileDto dto, Guid addressId)
    {
        User res = new();
        res.Id = dto.Id;
        res.FirstName = dto.FirstName;
        res.LastName = dto.LastName;
        res.AddressId = addressId;

        return res;
    }
}
