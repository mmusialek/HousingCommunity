﻿using Hocomm.Contracts.Evidences;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class EvidenceService : ServiceBase
{
    public EvidenceService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(CreateEvidenceItemDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        //_context.Add(entity);
        //_context.SaveChanges();

        if (dto.OwnerIds != null && dto.OwnerIds.Any())
        {
            foreach (var dtoItem in dto.OwnerIds)
            {
                EvidenceItemMember entityMember = new();
                entityMember.OwnedByUserId = dtoItem;
                entityMember.CreatedByUserId = _metadata.UserId;
                entityMember.EvidenceItem = entity;
                //entityMember.EvidenceItemId = entity.Id;
                //_context.Add(entityMember);
            }
        }
        _context.SaveChanges();

        return entity.Id;
    }

    public IList<EvidenceItemDto> Get(GetEvidenceItemsParams query)
    {
        var entities = _context.EvidenceItems.Where(q => q.HousingCommunityId == query.HousingCommunityId).GetPage(query.Page);
        var res = entities.Select(ToDto).ToList();
        return res;
    }

    public Guid Update(UpdateEvidenceItemDto dto)
    {
        var entity = _context.EvidenceItems.Single(q => q.Id == dto.EvidenceItemId);

        if (dto.FloorNr.HasValue)
        {
            entity.FloorNr = dto.FloorNr.Value;
        }

        if (!string.IsNullOrEmpty(dto.ShortDescription))
        {
            entity.ShortDescription = dto.ShortDescription;
        }

        if (dto.Area.HasValue)
        {
            entity.Area = dto.Area.Value;
        }

        if (dto.PersonCount.HasValue)
        {
            entity.PersonCount = dto.PersonCount.Value;
        }

        _context.SaveChanges();

        return entity.Id;
    }

    public void AddUsersToEvidence(AddEvidenceItemUsersDto dto)
    {
        if (dto.OwnerIds != null && dto.OwnerIds.Any())
        {
            foreach (var dtoItem in dto.OwnerIds)
            {
                EvidenceItemMember entityMember = new();
                entityMember.OwnedByUserId = dtoItem;
                entityMember.CreatedByUserId = _metadata.UserId;
                entityMember.EvidenceItemId = dto.EvidenceItemId;
                _context.Add(entityMember);
            }
            _context.SaveChanges();
        }
    }

    public static EvidenceItem ToEntity(CreateEvidenceItemDto dto, ServiceMetadata metadata)
    {
        EvidenceItem res = new();
        res.Nr = dto.Nr;
        res.FloorNr = dto.FloorNr;
        res.ShortDescription = dto.ShortDescription;
        res.Area = dto.Area;
        res.PersonCount = dto.PersonCount;
        res.CreatedByUserId = metadata.UserId;
        res.HousingCommunityId = dto.HousingCommunityId;
        res.EvidenceTypeId = dto.EvidenceTypeId;

        return res;
    }

    public static EvidenceItemDto ToDto(EvidenceItem entity)
    {
        EvidenceItemDto res = new();
        res.Id = entity.Id;
        res.Nr = entity.Nr;
        res.FloorNr = entity.FloorNr;
        res.ShortDescription = entity.ShortDescription;
        res.Area = entity.Area;
        res.PersonCount = entity.PersonCount;
        res.EvidenceTypeId = entity.EvidenceTypeId;

        return res;
    }
}
