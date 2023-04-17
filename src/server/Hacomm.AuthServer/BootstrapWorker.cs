using Hacomm.AuthServer.Database;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Hacomm.AuthServer
{
    public class BootstrapWorker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public BootstrapWorker(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await using var scope = _serviceProvider.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
            await context.Database.EnsureCreatedAsync();

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            var clientData = await manager.FindByClientIdAsync("webapp");
            if (clientData != null)
            {
                await manager.DeleteAsync(clientData);
            }

            if (await manager.FindByClientIdAsync("webapp") == null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "webapp",
                    //ClientSecret = "901564A5-E7FE-42CB-B10D-61EF6A8F3654",
                    ConsentType = ConsentTypes.Implicit,
                    DisplayName = "Client WebApp",
                    RedirectUris =
                {
                    new Uri("http://localhost:4200/profile")
                },
                    PostLogoutRedirectUris =
                {
                    new Uri("http://localhost:4200/logout")
                },
                    Permissions =
                {
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Logout,
                    Permissions.Endpoints.Token,

                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.RefreshToken,

                    Permissions.ResponseTypes.Code,

                    Permissions.Scopes.Email,
                    Permissions.Scopes.Profile,
                    Permissions.Scopes.Roles
                },
                    Requirements =
                {
                    Requirements.Features.ProofKeyForCodeExchange
                }
                });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
