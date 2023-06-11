using Microsoft.OpenApi.Models;

namespace Hocomm.WebApi.Bootstrap;

public static class SwaggerSetup
{
    public static void AddSwagger(this IServiceCollection services, string authServiceUrl)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            var baseAuthorizationServerUri = new Uri(authServiceUrl);
            c.AddSecurityDefinition("OAuth", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(baseAuthorizationServerUri, "connect/authorize"),
                        TokenUrl = new Uri(baseAuthorizationServerUri, "connect/token")
                    }
                },
                Type = SecuritySchemeType.OAuth2
            });

            //c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference { Id = "OAuth", Type = ReferenceType.SecurityScheme }
            //        },
            //        new List<string> { }
            //    }
            //});

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Hocomm API",
                Version = "v1"
            });
        });
    }

    public static void UseSwagger(this IApplicationBuilder app)
    {
        SwaggerBuilderExtensions.UseSwagger(app);
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hocomm API");
            //c.OAuthClientId("some client id");
            //c.OAuthScopes("some scope");
            c.OAuthUsePkce();
        });
    }
}

