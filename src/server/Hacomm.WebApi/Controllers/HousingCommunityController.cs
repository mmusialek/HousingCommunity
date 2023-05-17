using Hacomm.Contracts.Announcements;
using Hacomm.Contracts.HousingCommunities;
using Hacomm.Database.Entities;
using Hacomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hocomm.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class HousingCommunityController : ControllerBase
{
    private readonly HousingCommunityService _service;

    public HousingCommunityController(HousingCommunityService service, HttpContext httpContext)
    {
        _service = service;

        _service.SetMetaData(httpContext.GetMetadata());
    }

    [HttpGet]
    public HousingCommunityDto Get([FromQuery] GetHousingCommunityParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] AddHousingCommunityRequest request)
    {
        return await _service.AddAsync(request);
    }
}
