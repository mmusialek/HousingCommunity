using Hocomm.Contracts.InternalMessages;
using Hocomm.Contracts.Resolutions;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResolutionsController : ControllerBase
{
    private readonly ResolutionService _service;

    public ResolutionsController(ResolutionService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }


    [HttpPost]
    public Guid Post([FromBody] AddResolutionDto request)
    {
        return _service.Add(request);
    }


    [HttpGet]
    public IEnumerable<ResolutionDto> Post([FromQuery] GetResolutionParams request)
    {
        return _service.Get(request);
    }



    [HttpPost("vote")]
    public Guid Vote([FromBody] VoteResolutionDto request)
    {
        return _service.Vote(request);
    }

    [HttpPut]
    public Guid Put([FromBody] UpdateResolutionDto request)
    {
        return _service.Update(request);
    }
}
