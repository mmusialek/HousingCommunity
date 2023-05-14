using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetheria.AuthServer.Database;

public class AuthDbContext : IdentityDbContext<ApplicationUserEntity>

{
    public AuthDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseOpenIddict();
    }
}


public class AuthDbContextFactoryDesignTime : IDesignTimeDbContextFactory<AuthDbContext>
{
    private readonly string _connString = "Server=127.0.0.1;User Id=postgres;Password=postgres000;Database=postgres;";

    public AuthDbContext CreateDbContext(string[] args) => new(new DbContextOptionsBuilder<AuthDbContext>().UseNpgsql(_connString).Options);
}