using Hocomm.Contracts.Evidences;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EvidenceTypesController : ControllerBase
{
    private readonly EvidenceTypeItemSerivce _service;

    public EvidenceTypesController(EvidenceTypeItemSerivce service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpPost]
    public Guid Post([FromBody] CreateEvidenceTypeDto request)
    {
        return _service.Add(request);
    }

    [HttpGet]
    public IEnumerable<EvidenceTypeDto> Get([FromQuery] GetEvidenceTypeParams query)
    {
        return _service.Get(query);
    }

    [HttpPut]
    public Guid Put([FromBody] UpdateEvidenceTypeDto request)
    {
        return _service.Update(request);
    }
}
