using Hocomm.Contracts.Announcements;
using Hocomm.Services;
using Hocomm;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace Hocomm.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly AnnouncementService _service;

    public AnnouncementsController(AnnouncementService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpGet]
    public IEnumerable<AnnouncementDto> Get([FromQuery] GetAnnouncementParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public Guid Post([FromBody] AddAnnouncementRequest request)
    {
        return _service.Add(request);
    }

    [HttpPut]
    public async Task PutAsync(UpdateAnnouncementRequest request)
    {
        await _service.UpdateAsync(request);
    }
}
