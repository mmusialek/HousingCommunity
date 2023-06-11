using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Validation.AspNetCore;

namespace Hocomm.WebApi.Bootstrap;

public static class AuthSetup
{
    //public const string PolicyName = "hacomGeneralPolicy";

    public static void AddHocomAuth(this IServiceCollection services, string authorizationServerUri)
    {
        services.AddAuthentication(options =>
        {
            //options.DefaultAuthenticateScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });
        //.AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        // services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>();

        services.AddOpenIddict()
            .AddValidation(options =>
            {
                options.SetIssuer(authorizationServerUri);
                options
                    .UseIntrospection()
                    .SetClientId("hacomm_api")
                    .SetClientSecret("95d1f4e0-2f75-44c5-bb8e-2365bdfa8282");
                options.UseSystemNetHttp();
                options.UseAspNetCore();
            });

        //services.AddScoped<IAuthorizationHandler, some handler>();

        services.AddAuthorization(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
            options.FallbackPolicy = policy;
        });
    }
}
