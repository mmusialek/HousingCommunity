﻿using Hocomm.Contracts.Users;
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
    public UserService(PgSqlContext context) : base(context)
    {
    }

    public Guid CreateProfile(CreateUserProfileDto dto)
    {
        var address = AddressService.ToEntity(dto.Address);
        var userEntity = ToUserEntity(dto, address);

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

    public static User ToUserEntity(CreateUserProfileDto dto, Address address)
    {
        User res = new();
        res.Id = dto.Id;
        res.FirstName = dto.FirstName;
        res.LastName = dto.LastName;
        res.Address = address;

        return res;
    }
}
