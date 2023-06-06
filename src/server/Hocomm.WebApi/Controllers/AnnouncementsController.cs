﻿using Hocomm.Contracts.Announcements;
using Hocomm.Services;
using Hocomm;
using Hocomm.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace Hocomm.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly AnnouncementService _service;

    public AnnouncementsController(AnnouncementService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;

        _service.SetMetaData(httpContextAccessor.GetMetadata());
    }

    [HttpGet]
    public string Get([FromQuery] GetAnnouncementParams query)
    {
        _service.Get(query);
        return "ok";
    }

    [HttpPost]
    public async Task<string> Post([FromBody] AddAnnouncementRequest request)
    {
        await _service.AddAsync(request);
        return "ok";
    }

    [HttpPut]
    public async Task PutAsync(UpdateAnnouncementRequest request)
    {
        await _service.UpdateAsync(request);
    }
}
