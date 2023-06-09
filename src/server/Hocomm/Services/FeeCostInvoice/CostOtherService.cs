using Hocomm.Contracts.FeeCostInvoice;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services.FeeCostInvoice;
public class CostOtherService : ServiceBase
{
    public CostOtherService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddCostOtherDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        return AddAndSave(entity);
    }

    public Guid Update(UpdateCostOtherDto dto)
    {
        var entity = _context.CostOthers.First(q => q.Id == dto.Id);
        UpdateEntity(entity, dto, _metadata);
        _context.SaveChanges();
        return entity.Id;
    }

    public static CostOther ToEntity(AddCostOtherDto dto, ServiceMetadata metadata)
    {
        CostOther res = new();
        res.Name = dto.Name;
        res.InvoinceNumber = dto.InvoinceNumber;
        res.GrossValue = dto.GrossValue;
        res.HousingCommunityId = dto.HousingCommunityId;

        res.CreatedById = metadata.UserId;

        return res;
    }

    public static void UpdateEntity(CostOther entity, UpdateCostOtherDto dto, ServiceMetadata metadata)
    {
        entity.Name = dto.Name;
        entity.InvoinceNumber = dto.InvoinceNumber;
        entity.GrossValue = dto.GrossValue;
        entity.ModifiedById = metadata.UserId;
    }
}
