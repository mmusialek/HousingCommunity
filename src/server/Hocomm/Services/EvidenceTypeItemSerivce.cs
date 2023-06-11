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

    public Guid Add(CreateEvidenceTypeDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        AddAndSave(entity);

        return entity.Id;
    }

    public IList<EvidenceTypeDto> Get(GetEvidenceTypeParams query)
    {
        var entities = _context.EvidenceTypes.Where(q => q.HousingCommunityId == query.HousingCommunityId).GetPage(query.Page);
        var res = entities.Select(ToDto).ToList();
        return res;
    }

    public Guid Update(UpdateEvidenceTypeDto dto)
    {
        var entity = _context.EvidenceTypes.Single(q => q.Id == dto.EventTypeId && q.HousingCommunityId == dto.HousingCommunityId);
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

    public static EvidenceTypeDto ToDto(EvidenceType entity)
    {
        EvidenceTypeDto res = new();
        res.Id = entity.Id;
        res.Name = entity.Name;
        res.ShortDescription = entity.ShortDescription;

        return res;
    }
}
