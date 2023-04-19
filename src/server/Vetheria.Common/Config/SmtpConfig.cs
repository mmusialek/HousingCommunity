using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetheria.Common.Config;

public class SmtpConfig
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 8025;
    public string SystemEmail { get; set; } = "johnnythespammer@gmail.com";
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
