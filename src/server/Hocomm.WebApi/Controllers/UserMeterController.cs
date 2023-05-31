using Hocomm.Contracts.HousingCommunities;
using Hocomm.Contracts.UserMeters;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserMeterTypeController : ControllerBase
{
    private readonly UserMeterService _service;

    public UserMeterTypeController(UserMeterService service, HttpContext httpContext)
    {
        _service = service;

        _service.SetMetaData(httpContext.GetMetadata());
    }

    [HttpGet]
    public IReadOnlyList<UserMeterDto> Get([FromQuery] GetUserMeterParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] AddUserMeterRequest request)
    {
        return await _service.AddEntryAsync(request);
    }
}
