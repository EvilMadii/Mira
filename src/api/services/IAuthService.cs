using api.dal;
using api.models.dbEntities;
using api.contracts.requests;

namespace api.services;

public interface IAuthService
{
    public Task<string> Login(LoginRequest _request);
    public Task<bool> ValidateToken(string _token);
    public Task<string> Register(RegisterRequest _request);


}