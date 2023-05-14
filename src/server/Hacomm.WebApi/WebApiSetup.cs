using Hacomm.Database;
using Microsoft.EntityFrameworkCore;

namespace Hacomm.WebApi;

public static class WebApiSetup
{

    public static void AddNecessaryStuff(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<PgSqlContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddSingleton<Func<PgSqlContext>>(() => new PgSqlContext(new DbContextOptionsBuilder<PgSqlContext>()
            .UseNpgsql(connectionString).Options));

        services.AddHacommServices();
    }

    public static void UseHaComm(this IApplicationBuilder app)
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
