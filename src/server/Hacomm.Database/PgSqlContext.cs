using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Hacomm.Database.Entities;

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
}
