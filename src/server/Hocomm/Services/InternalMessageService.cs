using Hocomm.Contracts.InternalMessages;
using Hocomm.Database;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public class InternalMessageService : ServiceBase
{
    public InternalMessageService(PgSqlContext context) : base(context)
    {
    }

    public Guid AddMessage(CreateInternalMessageDto dto)
    {
        var entity = ToEntity(dto, _metadata);
        AddAndSave(entity);
        var entityConn = ToEntity(dto, entity.Id, _metadata);
        AddAndSave(entityConn);

        return entity.Id;
    }

    public static InternalMessage ToEntity(CreateInternalMessageDto dto, ServiceMetadata metadata)
    {
        InternalMessage res = new();
        res.Message = dto.Message;
        res.HousingCommunityId = dto.HousingCommunityId;

        return res;
    }

    public static InternalMessageConnection ToEntity(CreateInternalMessageDto dto, Guid internalMessageId, ServiceMetadata metadata)
    {
        InternalMessageConnection res = new();
        res.InternalMessageId = internalMessageId;
        res.FromUserId = metadata.UserId;
        res.ToUserId = dto.ToUserId;
        res.RecievedByUserId = dto.ToUserId;

        return res;
    }
}
