using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class InternalMessage
{
    //    InternalMessage
    //id, message, fromUserId, toUserId, housingCommunityId
    public Guid Id { get; set; }
    public string Message { get; set; } = null!;

    // ref
    public Guid FromUserId { get; set; }
    public User FromUser { get; set; } = null!;

    public Guid ToUserId { get; set; }
    public User ToUser { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public List<InternalMessageConnection> ParentInternalMessageConnections { get; set; } = null!;
    public List<InternalMessageConnection> ChildsInternalMessageConnections { get; set; } = null!;
}

public class InternalMessageConnection
{
    public Guid Id { get; set; }

    public Guid ParentInternalMessageId { get; set; }
    public InternalMessage ParentInternalMessage { get; set; } = null!;

    public Guid ChildInternalMessageId { get; set; }
    public InternalMessage ChildInternalMessage { get; set; } = null!;
}
