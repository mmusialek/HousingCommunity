using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Server.AspNetCore;

namespace Hacomm.WebApi.Controllers;

[Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class Announcements : ControllerBase
{
    public string Get()
    {
        return "ok";
    }
}
