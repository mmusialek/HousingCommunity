using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database.Entities;
public class Address
{
    public long Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HomeNr { get; set; }
    public int? FlatNrNr { get; set; }
}
