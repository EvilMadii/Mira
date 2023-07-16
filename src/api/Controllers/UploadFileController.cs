using Microsoft.AspNetCore.Mvc;
using api.services;
using Microsoft.AspNetCore.Authorization;

namespace api.controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UploadFileController : ControllerBase
{
    private readonly IUploadService _service;
    public UploadFileController(IUploadService service)
    {
        _service = service;
    }
    [Authorize]
    [HttpPost]
    [Route("{_id:guid}/image")]
    public async Task<IActionResult> UploadImage([FromForm(Name = "image")] IFormFile _image, [FromRoute] Guid _id)
    {
        var Response = await _service.UploadImageAsync(_id, _image);
        if (Response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(_id);
        }
        return BadRequest(_id);
    }

}