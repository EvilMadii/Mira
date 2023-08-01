using api.services;
using Microsoft.AspNetCore.Mvc;
using api.contracts.data;
using Microsoft.AspNetCore.Authorization;

namespace api.controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    [Authorize]
    [HttpGet]
    [Route("{emailOrGuid}")]
    public async Task<ActionResult<UserDTO>> GetByEmailOrGuid([FromRoute] string emailOrGuid)
    {
        var isGuid = Guid.TryParse(emailOrGuid, out var id);
        var user = isGuid ? await _service.GetByGuidAsync(id) : await _service.GetByEmailAsync(emailOrGuid);

        if (user is null)
            return NotFound();


        return Ok(user);
    }
    [Authorize]
    [HttpDelete]
    [Route("delete/{id:guid}")]
    public async Task<ActionResult> DeleteById([FromRoute] Guid id)
    {
        bool _result = await _service.DeleteAsync(id);
        return _result switch
        {
            true => Ok(),
            _ => BadRequest(),
        };
    }
    [Authorize]
    [HttpPut]
    [Route("update")]
    public async Task<ActionResult> Update([FromBody] UserDTO userDTO)
    {
        var result = await _service.UpdateAsync(userDTO);
        return result switch
        {
            true => Ok(userDTO.UserName),
            _ => BadRequest(),
        };
    }
}