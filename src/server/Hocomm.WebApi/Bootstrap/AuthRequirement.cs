using Microsoft.AspNetCore.Authorization;

namespace Hocomm.WebApi.Bootstrap;

public class AuthRequirement : IAuthorizationRequirement
{
    public string Scope { get; }

    public AuthRequirement(string scope)
    {
        Scope = scope;
    }
}
