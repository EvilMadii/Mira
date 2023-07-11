using api.dal;
using api.models.dbEntities;
using api.models.dto;

namespace api.services;

public interface IAuthService
{
    public Task<string> Login(LoginRequest _request);

}