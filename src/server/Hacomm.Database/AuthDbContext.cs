using Hacomm.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database;

public class AuthDbContext : IdentityDbContext<ApplicationUser>

{
    public AuthDbContext(DbContextOptions options) : base(options)
    {
    }
}
