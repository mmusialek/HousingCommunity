using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class CalendarEvent
{
    //    id createdAt eventDateFrom, evendDateTo, title, description, housingCommunityId, evidenceItemId?
    //recurrent, validFrom, mon, tue, wed, thu, fri, sat, sun, every week, every month, every year
    //creatorUserId

    public Guid Id { get; set; }
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
}

public class CalendarEventMembers
{
    //id, eventId, userId
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }
    public User Member { get; set; } = null!;

    public Guid CalendarEventId { get; set; }
    public CalendarEvent CalendarEvent { get; set; } = null!;
}
