using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database.Entities;
public class Address : BaseEntity
{
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string HomeNr { get; set; } = null!;
    public int? FlatNr { get; set; }

    //ref

    public IList<User> Users { get; set; } = null!;
    public IList<HousingCommunity> HousingCommunities { get; set; } = null!;
    public IList<Company> Companies { get; set; } = null!;
}

internal static class AddressModelBuilder
{    
    public static void Build(this ModelBuilder builder)
    {
        var entity = builder.Entity<Address>();

        entity.HasKey(q => q.Id);
        entity.Property(q => q.Id).HasDefaultValueSql("gen_random_uuid()");

        entity.Property(q => q.City).HasMaxLength(255).IsRequired();
        entity.Property(q => q.ZipCode).HasMaxLength(10).IsRequired();
        entity.Property(q => q.Street).HasMaxLength(255).IsRequired();
        entity.Property(q => q.HomeNr).HasMaxLength(10).IsRequired();
        entity.Property(q => q.FlatNr).IsRequired(false);
    }
}
