using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Hocomm.WebApi.Extensions;

public static class ControllerExtensions
{
    public static ServiceMetadata GetMetadata(this IHttpContextAccessor httpContext, bool noThrowAllowEmpty = false)
    {
        ServiceMetadata res = new();
        var user = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        if (noThrowAllowEmpty && user == null)
        {
            throw new ArgumentException("user cannot be null.");
        }

        if (user != null)
        {
            res.UserId = Guid.Parse(user.Value);
        }

        //var user = httpContext.User.FindFirst(ClaimTypes.NameIdentifier) ?? throw new ArgumentException("user cannot be null.");
        //var res = new ServiceMetadata(Guid.Parse(user.Value));

        return res;
    }
}
