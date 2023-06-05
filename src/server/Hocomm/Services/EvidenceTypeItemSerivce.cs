using Hocomm.Contracts.Evidences;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class EvidenceTypeItemSerivce : ServiceBase
{
    public EvidenceTypeItemSerivce(PgSqlContext context) : base(context)
    {
    }

    public Guid AddType(CreateEvidenceTypeDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        _context.Add(entity);
        _context.SaveChanges();

        return entity.Id;
    }

    public Guid UpdateType(UpdateEvidenceTypeDto dto)
    {
        var entity = _context.EvidenceTypes.First(q => q.Id == dto.EventTypeId && q.HousingCommunityId == dto.HousingCommunityId);
        // TODO check if user can modify entity

        entity.Name = dto.Name;
        entity.ShortDescription = dto.ShortDescription;
        _context.SaveChanges();

        return entity.Id;
    }

    public static EvidenceType ToEntity(CreateEvidenceTypeDto dto, ServiceMetadata metadata)
    {
        EvidenceType res = new();
        res.Name = dto.Name;
        res.ShortDescription = dto.ShortDescription;
        res.CreatedByUserId = metadata.UserId;
        res.HousingCommunityId = dto.HousingCommunityId;

        return res;
    }
}
