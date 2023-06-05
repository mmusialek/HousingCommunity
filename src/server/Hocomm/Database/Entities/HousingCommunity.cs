using Microsoft.EntityFrameworkCore;
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
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public IList<Announcement> Announcements { get; set; } = null!;
    public IList<EvidenceItem> EvidenceItems { get; set; } = null!;
    public IList<EvidenceType> EvidenceTypeItems { get; set; } = null!;
    public IList<EvidenceItemMember> EvidenceItemMembers { get; set; } = null!;

    public IList<User> Users { get; set; } = null!;
    public IList<UserMeter> UserMeters { get; set; } = null!;
    public IList<UserMeterType> UserMeterTypes { get; set; } = null!;
    public IList<Resolution> Resolutions { get; set; } = null!;
    public IList<InternalMessage> InternalMessages { get; set; } = null!;
    public IList<CalendarEvent> CalendarEvents { get; set; } = null!;
    public IList<FailureReport> FailureReports { get; set; } = null!;
    public IList<CostInvoice> CostInvoices { get; set; } = null!;
    public IList<CostOther> CostOthers { get; set; } = null!;
}


internal static class HousingCommunityModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var housingCommunity = builder.Entity<HousingCommunity>();
        housingCommunity.HasKey(q => q.Id);
        housingCommunity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        housingCommunity.Property(q => q.Name).HasMaxLength(255).IsRequired();
        housingCommunity.Property(q => q.ModifiedAt).IsRequired(false);
        housingCommunity.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        // ref
        housingCommunity.HasOne(q => q.Address).WithMany(q => q.HousingCommunities).HasForeignKey(q => q.AddressId);

    }
}
