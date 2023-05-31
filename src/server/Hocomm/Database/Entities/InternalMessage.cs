using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
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

internal static class InternalMessageModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<InternalMessage>();
        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Message).IsRequired();

        // ref
        entity.HasOne(q => q.FromUser).WithMany(q => q.FromInternalMessages).HasForeignKey(q => q.FromUserId);
        entity.HasOne(q => q.ToUser).WithMany(q => q.ToInternalMessages).HasForeignKey(q => q.ToUserId);
        entity.HasOne(q => q.HousingCommunity).WithMany(q => q.InternalMessages).HasForeignKey(q => q.HousingCommunityId);

        var entityInternalMessageConnection = builder.Entity<InternalMessageConnection>();
        entityInternalMessageConnection.HasKey(q => q.Id);
        entityInternalMessageConnection.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        // ref
        entityInternalMessageConnection.HasOne(q => q.ParentInternalMessage).WithMany(q => q.ParentInternalMessageConnections).HasForeignKey(q => q.ParentInternalMessageId);
        entityInternalMessageConnection.HasOne(q => q.ChildInternalMessage).WithMany(q => q.ChildsInternalMessageConnections).HasForeignKey(q => q.ChildInternalMessageId);
    }
}