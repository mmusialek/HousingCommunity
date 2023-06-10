using Hocomm.Contracts.HousingCommunities;
using Hocomm.Contracts.UserMeters;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserMeterController : ControllerBase
{
    private readonly UserMeterService _service;

    public UserMeterController(UserMeterService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }


    [HttpGet]
    public IReadOnlyList<UserMeterDto> Get([FromQuery] GetUserMeterParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] AddUserMeterRequest request)
    {
        return await _service.AddAsync(request);
    }
}
