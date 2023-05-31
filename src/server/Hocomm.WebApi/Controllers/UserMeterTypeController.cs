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
    private readonly UserMeterTypeService _service;

    public UserMeterController(UserMeterTypeService service, HttpContext httpContext)
    {
        _service = service;

        _service.SetMetaData(httpContext.GetMetadata());
    }


    [HttpGet]
    public IReadOnlyList<UserMeterTypeDto> Get([FromQuery] GetUserMeterTypeParams query)
    {
        return _service.Get(query);
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] AddUserMeterTypeRequest request)
    {
        return await _service.AddAsync(request);
    }
}
