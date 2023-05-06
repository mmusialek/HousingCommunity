using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Database;
static class DataModelBuilder
{
    internal static void BuildAll(this ModelBuilder builder)
    {
        builder.UseCollation("en_US.utf8");
    }
}
