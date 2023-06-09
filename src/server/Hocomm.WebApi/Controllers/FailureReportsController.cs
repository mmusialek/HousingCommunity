using Hocomm.Contracts.Evidences;
using Hocomm.Contracts.FailureReports;
using Hocomm.Services;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FailureReportsController : ControllerBase
{
    private readonly FailureReportService _service;

    public FailureReportsController(FailureReportService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpPost]
    public Guid Post([FromBody] CreateFailureReportDto request)
    {
        return _service.Add(request);
    }

    [HttpPost("AddComment")]
    public Guid AddComment([FromBody] AddFailureReportCommentDto request)
    {
        return _service.AddComment(request);
    }

    [HttpPost("ChangeStatus")]
    public Guid ChangeStatus([FromBody] ChangeFailureReportStatusDto request)
    {
        return _service.ChangeStatus(request);
    }
}
