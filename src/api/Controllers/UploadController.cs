using System.Security.Principal;
using api.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;
    private readonly IUserImageService _userService;
    public UploadController(IUploadService uploadService, IUserImageService userService)
    {
        _uploadService = uploadService;
        _userService = userService;
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Upload(Guid _uuid, [FromForm] IFormFile _file)
    {
        var response = await _uploadService.UploadAsync(_uuid, _file);

    }
}