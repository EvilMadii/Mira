using System.Security.Principal;
using api.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;
    private readonly IAuthService _authService;

    public UploadController(IUploadService uploadService, IAuthService authService)
    {
        _uploadService = uploadService;
        _authService = authService;
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Upload([FromHeader] string _token, [FromForm] IFormFile file)
    {
        string _guid = _authService.GetGuidFromJWT(_token);
        var response = await _uploadService.UploadAsync(Guid.Parse(_guid), file);
        throw new NotImplementedException();
    }
}