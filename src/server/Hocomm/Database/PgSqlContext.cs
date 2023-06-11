using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Hocomm.Database.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Hocomm.Database;
public class PgSqlContext : DbContext
{

    public PgSqlContext(DbContextOptions<PgSqlContext> options) : base(options)
    {
        ChangeTracker.StateChanged += ChangeTracker_StateChanged;
    }

    private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
    {
        var now = DateTime.UtcNow;

        if (e.Entry.Entity is IDateEntity entity)
        {
            if (e.NewState == EntityState.Modified)
            {
                entity.ModifiedAt = now;
            }
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.BuildAll();
    }

    public DbSet<Announcement> Announcements { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<HousingCommunity> HousingCommunities { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserMeter> UserMeters { get; set; } = null!;
    public DbSet<UserMeterType> UserMeterTypes { get; set; } = null!;

    public DbSet<FailureReport> FailureReports { get; set; } = null!;
    public DbSet<FailureReportAttachement> FailureReportAttachements { get; set; } = null!;
    public DbSet<FailureReportComment> FailureReportComments { get; set; } = null!;

    public DbSet<EvidenceItem> EvidenceItems { get; set; } = null!;
    public DbSet<EvidenceType> EvidenceTypes { get; set; } = null!;
    public DbSet<EvidenceItemMember> EvidenceItemMembers { get; set; } = null!;
    public DbSet<InternalMessageConnection> InternalMessageConnections { get; set; } = null!;
    public DbSet<InternalMessage> InternalMessages { get; set; } = null!;

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CostInvoice> CostInvoices { get; set; } = null!;
    public DbSet<CostOther> CostOthers { get; set; } = null!;
    public DbSet<EvidenceFee> EvidenceFees { get; set; } = null!;
    public DbSet<EvidenceFeeItem> EvidenceFeeItems { get; set; } = null!;
    
    public DbSet<Resolution> Resolutions { get; set; } = null!;
}

public class AuthDbContextFactoryDesignTime : IDesignTimeDbContextFactory<PgSqlContext>
{
    private readonly string _connString = "Server=127.0.0.1;User Id=postgres;Password=postgres000;Database=hocomm;";

    public PgSqlContext CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<PgSqlContext>().UseNpgsql(_connString).Options);
}
