using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public abstract class ServiceBase
{
    protected ServiceMetadata _metadata = null!;
    protected readonly PgSqlContext _context;

    public ServiceBase(PgSqlContext context)
    {
        _context = context;
    }

    public void SetMetaData(ServiceMetadata metadata)
    {
        _metadata = metadata;
    }

    protected Guid AddAndSave<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _context.Add(entity);
        _context.SaveChanges();

        return entity.Id;
    }

    protected IList<Guid> AddRangeAndSave<TEntity>(IList<TEntity> entity) where TEntity : BaseEntity
    {
        _context.AddRange(entity);
        _context.SaveChanges();

        return entity.Select(q => q.Id).ToList();
    }
}
