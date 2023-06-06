using Hocomm.Contracts.Announcements;
using Hocomm.Contracts.HousingCommunities;
using Hocomm.Database.Entities;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hocomm.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class HousingCommunitiesController : ControllerBase
{
    private readonly HousingCommunityService _service;

    public HousingCommunitiesController(HousingCommunityService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpGet]
    public HousingCommunityDto Get([FromQuery] GetHousingCommunityParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public Guid Post([FromBody] AddHousingCommunityRequest request)
    {
        return _service.Add(request);
    }
}
