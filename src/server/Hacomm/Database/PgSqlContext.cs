using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Hacomm.Database.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Hacomm.Database;
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

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var connString = PgConnection.GetConnecitonString();
        builder.UseNpgsql(connString);
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
}

public class AuthDbContextFactoryDesignTime : IDesignTimeDbContextFactory<PgSqlContext>
{
    private readonly string _connString = "Server=127.0.0.1;User Id=postgres;Password=postgres000;Database=hacomm;";

    public PgSqlContext CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<PgSqlContext>().UseNpgsql(_connString).Options);
}
