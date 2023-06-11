using Hocomm.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm;
public static class ServiceMap
{
    public static void AddHocommServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(AddressService));
        services.AddScoped(typeof(AnnouncementService));
        services.AddScoped(typeof(EvidenceService));
        services.AddScoped(typeof(EvidenceTypeItemSerivce));
        services.AddScoped(typeof(FailureReportService));
        services.AddScoped(typeof(HousingCommunityService));
        services.AddScoped(typeof(InternalMessageService));
        services.AddScoped(typeof(ResolutionService));
        services.AddScoped(typeof(UserMeterService));
        services.AddScoped(typeof(UserMeterTypeService));
        services.AddScoped(typeof(UserService));
    }
}
