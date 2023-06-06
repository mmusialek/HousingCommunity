using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class CalendarEvent : BaseEntity
{
    //    id createdAt eventDateFrom, evendDateTo, title, description, housingCommunityId, evidenceItemId?
    //recurrent, validFrom, mon, tue, wed, thu, fri, sat, sun, every week, every month, every year
    //creatorUserId
    public DateTime CreatedAt { get; set; }
    public DateTime EventDateFrom { get; set; }
    public DateTime EvendDateTo { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    // date fields

    public bool IsRecurrent { get; set; } = false;
    public DateTime? ValidFrom { get; set; }

    public bool? Monday { get; set; }
    public bool? Tuesday { get; set; }
    public bool? Wednesday { get; set; }
    public bool? Thursday { get; set; }
    public bool? Friday { get; set; }
    public bool? Saturday { get; set; }
    public bool? Sunday { get; set; }
    public bool? EveryWeek { get; set; }
    public bool? EveryMonth { get; set; }
    public bool? EveryYear { get; set; }


    // ref
    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public Guid? EvidenceItemId { get; set; }
    public EvidenceItem? EvidenceItem { get; set; } = null!;

    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;

    // ref list
    public IList<CalendarEventMember> CalendarEventMembers { get; set; } = null!;
}

public class CalendarEventMember : BaseEntity
{
    //id, eventId, userId

    public Guid MemberId { get; set; }
    public User Member { get; set; } = null!;

    public Guid CalendarEventId { get; set; }
    public CalendarEvent CalendarEvent { get; set; } = null!;
}


internal static class CalendarEventModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var calendarEvent = builder.Entity<CalendarEvent>();
        calendarEvent.HasKey(q => q.Id);
        calendarEvent.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        calendarEvent.Property(q => q.CreatedAt).IsRequired();
        calendarEvent.Property(q => q.EventDateFrom).IsRequired();
        calendarEvent.Property(q => q.EvendDateTo).IsRequired();

        calendarEvent.Property(q => q.Title).HasMaxLength(100).IsRequired();
        calendarEvent.Property(q => q.Description).IsRequired();

        calendarEvent.Property(q => q.IsRecurrent).IsRequired().HasDefaultValue(false);
        calendarEvent.Property(q => q.ValidFrom).IsRequired(false);

        calendarEvent.Property(q => q.Monday).IsRequired(false);
        calendarEvent.Property(q => q.Tuesday).IsRequired(false);
        calendarEvent.Property(q => q.Wednesday).IsRequired(false);
        calendarEvent.Property(q => q.Thursday).IsRequired(false);
        calendarEvent.Property(q => q.Friday).IsRequired(false);
        calendarEvent.Property(q => q.Saturday).IsRequired(false);
        calendarEvent.Property(q => q.Sunday).IsRequired(false);
        calendarEvent.Property(q => q.EveryWeek).IsRequired(false);
        calendarEvent.Property(q => q.EveryMonth).IsRequired(false);
        calendarEvent.Property(q => q.EveryYear).IsRequired(false);


        calendarEvent.HasOne(q => q.HousingCommunity).WithMany(q => q.CalendarEvents).HasForeignKey(q => q.HousingCommunityId);
        calendarEvent.HasOne(q => q.EvidenceItem).WithMany(q => q.CalendarEvents).HasForeignKey(q => q.EvidenceItemId);
        calendarEvent.HasOne(q => q.Author).WithMany(q => q.CalendarEvents).HasForeignKey(q => q.AuthorId);


        var calendarEventMember = builder.Entity<CalendarEventMember>();
        calendarEventMember.HasKey(q => q.Id);
        calendarEventMember.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        calendarEventMember.HasOne(q => q.Member).WithMany(q => q.CalendarEventMembers).HasForeignKey(q => q.MemberId);
        calendarEventMember.HasOne(q => q.CalendarEvent).WithMany(q => q.CalendarEventMembers).HasForeignKey(q => q.CalendarEventId);
    }
}