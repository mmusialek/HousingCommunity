using Hocomm.Contracts.FeeCostInvoice;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services.FeeCostInvoice;
public class CompanyService : ServiceBase
{
    public CompanyService(PgSqlContext context) : base(context)
    {
    }

    public Guid Add(CreateCompanyDto dto)
    {
        var entity = ToEntity(dto);
        var address = AddressService.ToEntity(dto.Address);
        entity.Address = address;
        AddAndSave(entity);
        return entity.Id;
    }

    private Company ToEntity(CreateCompanyDto dto)
    {
        var res = new Company();
        res.Name = dto.Name;
        res.Nip = dto.Nip;

        return res;
    }
}
