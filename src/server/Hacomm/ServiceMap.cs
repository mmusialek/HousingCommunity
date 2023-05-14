using Hacomm.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm;
public static class ServiceMap
{
    public static void AddHacommServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(AnnouncementService));
    }
}
