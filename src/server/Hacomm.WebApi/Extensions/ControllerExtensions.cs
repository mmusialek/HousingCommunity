using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Hocomm.WebApi.Extensions;

public static class ControllerExtensions
{
    public static ServiceMetadata GetMetadata(this HttpContext httpContext)
    {
        var user = httpContext.User.FindFirst(ClaimTypes.NameIdentifier) ?? throw new ArgumentException("user cannot be null.");
        var res = new ServiceMetadata(Guid.Parse(user.Value));

        return res;
    }
}
