using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;


    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public IList<Announcement> Announcements { get; set; } = null!;
    public IList<HousingCommunity> HousingCommunities { get; set; } = null!;
    public IList<UserMeter> UserMeters { get; set; } = null!;
    public IList<EvidenceItem> EvidenceItems { get; set; } = null!;
    public IList<EvidenceItemMember> EvidenceItemMemberOwnedByUser { get; set; } = null!;
    public IList<EvidenceItemMember> EvidenceItemMemberCreatedBy { get; set; } = null!;

    public IList<ResolutionVote> ResolutionVotes { get; set; } = null!;
    public IList<Resolution> Resolutions { get; set; } = null!;    
    public IList<FailureReport> FailureReports { get; set; } = null!;
    public IList<FailureReportComment> FailureReportsComments { get; set; } = null!;
    public IList<FailureReportAttachement> FailureReportAttachements { get; set; } = null!;
    public IList<EvidenceType> EvidenceTypeItems { get; set; } = null!;
    public IList<CalendarEvent> CalendarEvents { get; set; } = null!;
    public IList<CalendarEventMember> CalendarEventMembers { get; set; } = null!;
    public IList<InternalMessageConnection> FromUserInternalMessageConnections { get; set; } = null!;
    public IList<InternalMessageConnection> ToUserInternalMessageConnections { get; set; } = null!;
    public IList<InternalMessageConnection> RecievedByUserInternalMessageConnections { get; set; } = null!;
}


internal static class UserModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<User>();
        entity.HasKey(q => q.Id);
        // key should be added the same what AspNetUsers have

        entity.Property(q => q.FirstName).HasMaxLength(100).IsRequired();
        entity.Property(q => q.LastName).HasMaxLength(100).IsRequired();

        //ref
        entity.HasOne(q => q.Address).WithMany(q => q.Users).HasForeignKey(q => q.AddressId);
    }
}