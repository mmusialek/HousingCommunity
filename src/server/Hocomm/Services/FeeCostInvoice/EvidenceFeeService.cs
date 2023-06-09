using Hocomm.Contracts.FeeCostInvoice;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services.FeeCostInvoice;
public class EvidenceFeeService : ServiceBase
{
    public EvidenceFeeService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddEvidenceFeeDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        return AddAndSave(entity);
    }

    public Guid Update(UpdateEvidenceFeeDto dto)
    {
        var entity = _context.EvidenceFees.First(q => q.Id == dto.Id);
        UpdateEntity(entity, dto, _metadata);

        entity.EvidenceFeeItems.Clear();

        entity.EvidenceFeeItems = new List<EvidenceFeeItem>();
        foreach (var item in dto.EvidenceFeeItems)
        {
            entity.EvidenceFeeItems.Add(ToEntity(item));
        }

        //var idEntities = dto.EvidenceFeeItems.Where(q => q.Id != null && q.Id != Guid.Empty);
        //var nullEntities = dto.EvidenceFeeItems.Where(q => q.Id == null || q.Id == Guid.Empty);

        _context.SaveChanges();

        return entity.Id;
    }

    private static EvidenceFee ToEntity(AddEvidenceFeeDto dto, ServiceMetadata metadata)
    {
        EvidenceFee res = new();
        res.FeeNr = dto.FeeNr;
        res.PaidTo = dto.PaidTo;
        res.Status = dto.Status;
        res.EvidenceItemId = dto.EvidenceItemId;
        res.CreatedById = metadata.UserId;

        res.EvidenceFeeItems = new List<EvidenceFeeItem>();
        foreach (var item in dto.EvidenceFeeItems)
        {
            res.EvidenceFeeItems.Add(ToEntity(item));
        }

        return res;
    }

    private static EvidenceFeeItem ToEntity(EvidenceFeeItemDto dto)
    {
        EvidenceFeeItem res = new();
        res.Name = dto.Name;
        res.GrossValue = dto.GrossValue;

        return res;
    }

    private static void UpdateEntity(EvidenceFee entity, UpdateEvidenceFeeDto dto, ServiceMetadata metadata)
    {
        entity.FeeNr = dto.FeeNr;
        entity.PaidTo = dto.PaidTo;
        entity.Status = dto.Status;
        entity.EvidenceItemId = dto.EvidenceItemId;
        entity.ModifiedById = metadata.UserId;
    }


}
