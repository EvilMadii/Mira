using Microsoft.AspNetCore.Mvc;
using api.services;
using Microsoft.AspNetCore.Authorization;
using Amazon.S3;

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
    [Authorize]
    [HttpDelete]
    [Route("{_id:guid}")]
    public async Task<IActionResult> DeleteImageByGuid([FromRoute] Guid _id)
    {
        try
        {
            var response = await _service.DeleteImageAsync(_id);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return Ok();
            else
                return BadRequest();
        }
        catch (AmazonS3Exception ex) when (ex.Message is "The specified key does not exist.")
        {
            return NotFound();
        }
    }

}