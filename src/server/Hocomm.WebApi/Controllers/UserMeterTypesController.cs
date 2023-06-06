using Hocomm.Contracts.HousingCommunities;
using Hocomm.Contracts.UserMeters;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserMeterTyperController : ControllerBase
{
    private readonly UserMeterTypeService _service;

    public UserMeterTyperController(UserMeterTypeService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] AddUserMeterTypeRequest request)
    {
        return await _service.AddAsync(request);
    }


    [HttpGet]
    public IReadOnlyList<UserMeterTypeDto> Get([FromQuery] GetUserMeterTypeParams query)
    {
        return _service.Get(query);
    }
}
