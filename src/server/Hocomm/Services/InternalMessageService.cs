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

    public Guid Add(CreateInternalMessageDto dto)
    {
        var internalMessage = ToEntity(dto, _metadata);
        var entityConn = ToEntity(dto, internalMessage, _metadata);
        AddRangeAndSave(entityConn);

        return internalMessage.Id;
    }

    public IList<InternalMessageDto> Get(GetInternalMessageParams query)
    {
        var entities = _context.InternalMessageConnections.Where(q => q.RecievedByUserId == _metadata.UserId).GetPage(query.Page);

        var eq = from messageConnection in _context.Set<InternalMessageConnection>()
                 join message in _context.Set<InternalMessage>()
                 on messageConnection.InternalMessageId equals message.Id
                 where messageConnection.RecievedByUserId == _metadata.UserId
                 //select new { message.Id, message.Message, RecievedAt = message.CreatedAt, messageConnection.FromUserId };
                 select new InternalMessageDto { Id = message.Id, Message = message.Message, RecievedAt = message.CreatedAt, FromUserId = messageConnection.FromUserId };

        //var res = new List<InternalMessageDto>();
        var res = eq.ToList();
        //foreach (var entityItem in eq)
        //{
        //    InternalMessageDto tmp = new();
        //    tmp.Id = entityItem.Id;
        //    tmp.Message = entityItem.Message;
        //    tmp.RecievedAt = entityItem.RecievedAt;
        //    tmp.FromUserId = entityItem.FromUserId;
        //}

        return res;
    }

    public static InternalMessage ToEntity(CreateInternalMessageDto dto, ServiceMetadata metadata)
    {
        InternalMessage res = new();
        res.Message = dto.Message;
        res.HousingCommunityId = dto.HousingCommunityId;

        return res;
    }

    public static IList<InternalMessageConnection> ToEntity(CreateInternalMessageDto dto, InternalMessage internalMessage, ServiceMetadata metadata)
    {
        InternalMessageConnection toUserEntityCopy = new();
        toUserEntityCopy.InternalMessage = internalMessage;
        toUserEntityCopy.FromUserId = metadata.UserId;
        toUserEntityCopy.ToUserId = dto.ToUserId;
        toUserEntityCopy.RecievedByUserId = dto.ToUserId;

        InternalMessageConnection fromUserEntityCopy = new();
        fromUserEntityCopy.InternalMessage = internalMessage;
        fromUserEntityCopy.FromUserId = metadata.UserId;
        fromUserEntityCopy.ToUserId = dto.ToUserId;
        fromUserEntityCopy.RecievedByUserId = dto.ToUserId;

        return new[] { fromUserEntityCopy, toUserEntityCopy };
    }

    private InternalMessageDto ToDto(InternalMessageConnection entity)
    {
        throw new NotImplementedException();
    }
}
