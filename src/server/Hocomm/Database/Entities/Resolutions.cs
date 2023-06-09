using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;


public enum ResolutionVotesType
{
    None = 0,
    Yes = 1,
    No = 2
}

public class Resolution : BaseEntity, IDateEntity
{
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    // ref
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;

    public Guid HousingCommunityId { get; set; }
    public HousingCommunity HousingCommunity { get; set; } = null!;

    public IList<ResolutionVote> ResolutionVotes { get; set; } = null!;
}

public class ResolutionVote : BaseEntity
{
    public ResolutionVotesType Type { get; set; }
    public DateTime CreatedAt { get; set; }

    // ref
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public Guid ResolutionId { get; set; }
    public Resolution Resolution { get; set; } = null!;
}

internal static class ResolutionModelBuilder
{
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<Resolution>();
        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.Title).HasMaxLength(100).IsRequired();
        entity.Property(q => q.Message).IsRequired();

        entity.Property(q => q.ModifiedAt).IsRequired(false);
        entity.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        //ref
        entity.HasOne(q => q.CreatedBy).WithMany(q => q.Resolutions).HasForeignKey(q => q.CreatedById);
        entity.HasOne(q => q.HousingCommunity).WithMany(q => q.Resolutions).HasForeignKey(q => q.HousingCommunityId);


        var entityResolutionVote = builder.Entity<ResolutionVote>();
        entityResolutionVote.HasKey(q => q.Id);
        entityResolutionVote.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entityResolutionVote.Property(q => q.Type).IsRequired();
        entityResolutionVote.Property(q => q.CreatedAt).HasDefaultValueSql("timezone('utc', now())");

        // ref
        entityResolutionVote.HasOne(q => q.Author).WithMany(q => q.ResolutionVotes).HasForeignKey(q => q.AuthorId);
        entityResolutionVote.HasOne(q => q.Resolution).WithMany(q => q.ResolutionVotes).HasForeignKey(q => q.ResolutionId);
    }
}
