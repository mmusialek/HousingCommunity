using Hocomm.Contracts.Announcements;
using Hocomm.Contracts.Evidences;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EvidencesController : ControllerBase
{
    private readonly EvidenceService _service;

    public EvidencesController(EvidenceService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpPost]
    public Guid Post([FromBody] CreateEvidenceItemDto request)
    {
        return _service.AddEvidence(request);
    }

    [HttpPut]
    public Guid UpdateEvidence([FromBody] UpdateEvidenceItemDto request)
    {
        return _service.UpdateEvidenceItem(request);
    }

    [HttpPut("evidenceUsers")]
    public Guid UpdateEvidenceItemUsers([FromBody] UpdateEvidenceItemDto request)
    {
        return _service.UpdateEvidenceItem(request);
    }

}
