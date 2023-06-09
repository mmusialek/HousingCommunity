using Hocomm.Contracts.HousingCommunities;
using Hocomm.Contracts.InternalMessages;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InternalMessageController : ControllerBase
{
    private readonly InternalMessageService _service;

    public InternalMessageController(InternalMessageService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpPost]
    public Guid Post([FromBody] CreateInternalMessageDto request)
    {
        return _service.Add(request);
    }
}
