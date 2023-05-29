using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class HousingCommunity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public IList<Announcement> Announcements { get; set; } = null!;
    public IList<EvidenceItem> EvidenceItems { get; set; } = null!;
    public IList<EvidenceTypeItem> EvidenceTypeItems { get; set; } = null!;
    public IList<EvidenceItemMember> EvidenceItemMembers { get; set; } = null!;

    public IList<User> Users { get; set; } = null!;
    public IList<UserMeter> UserMeters { get; set; } = null!;
    public IList<UserMeterType> UserMeterTypes { get; set; } = null!;
    public IList<Resolution> Resolutions { get; set; } = null!;
    public IList<InternalMessage> ToUserInternalMessages { get; set; } = null!;
    public IList<InternalMessage> FromUserInternalMessages { get; set; } = null!;
    public IList<CalendarEvent> CalendarEvents { get; set; } = null!;
    public IList<FailureReport> FailureReports { get; set; } = null!;
    public IList<CostInvoice> CostInvoices { get; set; } = null!;
    public IList<CostOther> CostOthers { get; set; } = null!;
}
