using Hocomm.Database;
using Microsoft.EntityFrameworkCore;

namespace Hocomm.WebApi.Bootstrap;

public static class WebApiSetup
{

    public static void AddHocommStuff(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<PgSqlContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddSingleton<Func<PgSqlContext>>(() => new PgSqlContext(new DbContextOptionsBuilder<PgSqlContext>()
            .UseNpgsql(connectionString).Options));

        services.AddHocommServices();
    }

    public static void UseHocomm(this IApplicationBuilder app)
    {
        app.MigrateDatabase();
    }

    private static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PgSqlContext>();
        db.Database.Migrate();
    }
}
