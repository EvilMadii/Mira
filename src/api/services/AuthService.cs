using System.Text;
using api.dal;
using api.models.dbEntities;
using api.models.dto;
using Microsoft.EntityFrameworkCore;
namespace api.services;

public class AuthService : IAuthService
{
    private readonly RailwayContext _context;
    // Constructors
    public AuthService()
    {
        _context = new RailwayContext();
    }
    public AuthService(RailwayContext context)
    {
        _context = context;
    }

    public async Task<string> Login(LoginRequest _request)
    {
        User _user = await _context.Users.SingleOrDefaultAsync(usr => usr.UserName == _request.Username);
        if (_user is null)
            return "";
        if (_comparePasswords(_user.Password, _user.Salt, Encoding.UTF8.GetBytes(_request.Password)))
            return _generateWebToken(_user);
        else
            return "";
    }
    private string _generateWebToken(User _userObject)
    {

    }
    private bool _comparePasswords(byte[] _userPassword, string _userSalt, byte[] _requestPassword)
    {

    }
}