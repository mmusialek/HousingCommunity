using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database;
public class PgConnection
{
    private static string _connString = "Host=localhost;Database=eef;Username=postgres;Password=postgres000;";

    public static string GetConnecitonString()
    {
#if DEBUG
        _connString += "IncludeErrorDetail=true;";
#endif
        return _connString;
    }
}
