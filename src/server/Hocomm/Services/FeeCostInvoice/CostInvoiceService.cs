using Hocomm.Contracts.FeeCostInvoice;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services.FeeCostInvoice;
public class CostInvoiceService : ServiceBase
{
    public CostInvoiceService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(AddCostInvoiceDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        return AddAndSave(entity);
    }

    public Guid Update(UpdateCostInvoiceDto dto)
    {
        var entity = _context.CostInvoices.First(q => q.Id == dto.Id);
        UpdateEntity(entity, dto, _metadata);

        _context.SaveChanges();
        return entity.Id;
    }

    public static CostInvoice ToEntity(AddCostInvoiceDto dto, ServiceMetadata metadata)
    {
        CostInvoice res = new();
        res.Name = dto.Name;
        res.InvoinceNumber = dto.InvoinceNumber;
        res.IssuedAt = dto.IssuedAt;
        res.DueTo = dto.DueTo;
        res.GrossValue = dto.GrossValue;
        res.NetValue = dto.NetValue;
        res.VatValue = dto.VatValue;
        res.HousingCommunityId = dto.HousingCommunityId;
        res.IssuedByCompanyId = dto.IssuedByCompanyId;

        res.CreatedById = metadata.UserId;

        return res;
    }

    public static void UpdateEntity(CostInvoice entity, UpdateCostInvoiceDto dto, ServiceMetadata metadata)
    {
        entity.Name = dto.Name;
        entity.InvoinceNumber = dto.InvoinceNumber;
        entity.IssuedAt = dto.IssuedAt;
        entity.DueTo = dto.DueTo;
        entity.GrossValue = dto.GrossValue;
        entity.NetValue = dto.NetValue;
        entity.VatValue = dto.VatValue;
        entity.IssuedByCompanyId = dto.IssuedByCompanyId;

        entity.ModifiedById = metadata.UserId;
    }
}
