using api.models.dbEntities;
using api.contracts.requests;
using api.dal;
using api.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api.controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    public AuthController(IAuthService service)
    {
        _service = service;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login(LoginRequest _loginRequest)
    {
        if (string.IsNullOrEmpty(_loginRequest.ClientIP))
        {
            return BadRequest(_loginRequest);
        }
        string _token = await _service.Login(_loginRequest);
        if (!string.IsNullOrEmpty(_token))
        {
            return Ok(_token);
        }
        else
        {
            return BadRequest(_loginRequest);
        }
    }
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<string>> Register(RegisterRequest _registerRequest)
    {
        if (string.IsNullOrEmpty(_registerRequest.ClientIP))
            return BadRequest(_registerRequest);

        string _token = await _service.Register(_registerRequest);
        string[] _possibleErrors = new string[] {
            "Username Already In Use",
            "Email Already In Use",
            "failed to create user"
        };
        if (_possibleErrors.Any(item => item == _token))
            return BadRequest(_registerRequest);
        else
            return _token;
    }
    [HttpGet]
    [Route("Auth")]
    public async Task<IActionResult> Auth(string _token)
    {
        if (await _service.ValidateToken(_token))
            return Ok();
        else
            return Unauthorized();
    }

}