using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class Announcement : BaseEntity, IDateEntity
{
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? ValidTo { get; set; }

    // ref
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;
}


internal static class AnnouncementModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<Announcement>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Title).HasMaxLength(100).IsRequired();
        entity.Property(q => q.Message).IsRequired();
        entity.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        entity.HasOne(q => q.Author).WithMany(q => q.Announcements).HasForeignKey(q => q.AuthorId);
        entity.HasOne(q => q.HousingCommunity).WithMany(q => q.Announcements).HasForeignKey(q => q.HousingCommunityId);
    }
}