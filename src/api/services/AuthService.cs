using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using api.dal;
using api.models.dbEntities;
using api.models.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.services;

public class AuthService : IAuthService
{
    /* 
    * Jerk off to this service while you look for errors for me :3 x
    */
    private readonly RailwayContext _context;
    private readonly IConfigurationRoot _config;
    // Constructors

    public AuthService()
    {
        _context = new RailwayContext();
    }
    public AuthService(RailwayContext context)
    {
        _context = context;
        _config = new ConfigurationBuilder().AddUserSecrets<AuthService>().Build();
    }

    public async Task<string> Login(LoginRequest _request)
    {
        User _user = await _context.Users.SingleOrDefaultAsync(usr => usr.UserName == _request.Username);
        if (_user is null)
            return "";
        string _hashedPasswordAttempt = HashPassword(_user.Salt, _request.Password);
        string _hashedPassword = Encoding.UTF8.GetString(_user.Password);
        if (_hashedPasswordAttempt == _hashedPassword)
        {
            _user.LastLogin = DateTime.Now;
            _context.Entry(_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _generateWebToken(_user);
        }
        else
            return "";
    }

    public async Task<string> Register(RegisterRequest _request)
    {
        if (await _context.Users.AnyAsync(usr => usr.UserName == _request.UserName))
            return "Username Already In Use";
        if (await _context.Users.AnyAsync(usr => usr.Email == _request.Email))
            return "Email Already In Use";
        string _salt = SaltGen();
        string _passwordStr = HashPassword(_salt, _request.Password);//
        byte[] _password = Encoding.UTF8.GetBytes(_passwordStr);
        User _userToCreate = new User
        {
            UserId = Guid.NewGuid(),
            UserName = _request.UserName,
            Email = _request.Email.ToLower(),
            Password = _password,
            UserProfileImageUrl = "",
            Salt = _salt,
            Datecreated = DateTime.Now,
            LastLogin = DateTime.Now,
            LastPfpUpdate = DateTime.Now.AddHours(-24),
            Isactive = true
        };
        await _context.AddAsync(_userToCreate);
        await _context.SaveChangesAsync();
        if (_context.Users.Any(usr => usr.Email == _request.Email.ToLower()))
            return _generateWebToken(_userToCreate);
        else
            return "failed to create user";
    }

    public async Task<bool> ValidateToken(string _token)
    {
        if (string.IsNullOrEmpty(_token))
            return false;
        TokenValidationParameters _validationParameters = new TokenValidationParameters
        {
            ValidIssuer = new JWTHelper().Issuer,
            ValidAudience = new JWTHelper().Audience,
            IssuerSigningKey = new SymmetricSecurityKey(new JWTHelper().Key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.FromSeconds(30),
        };
        JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            ClaimsPrincipal _tokenValid = _tokenHandler.ValidateToken(_token, _validationParameters, out SecurityToken _validToken);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    private string _generateWebToken(User _userObject)
    {
        JWTHelper _helper = new JWTHelper();
        IEnumerable<Claim> _claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, _userObject.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, _userObject.Email),
            new Claim(JwtRegisteredClaimNames.Email, _userObject.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, _userObject.UserName)
        };
        SecurityTokenDescriptor _tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(_claims),
            Expires = DateTime.Now.AddHours(1),
            Audience = _helper.Audience,
            Issuer = _helper.Issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_helper.Key), SecurityAlgorithms.HmacSha256),
            IssuedAt = DateTime.Now
        };
        JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken _token = _tokenHandler.CreateToken(_tokenDescriptor);
        return _tokenHandler.WriteToken(_token);

    }
    public string HashPassword(string _salt, string _password)
    {
        HMACSHA256 _hashingAlg = new HMACSHA256(Encoding.UTF8.GetBytes(_config["HashingKey"]));
        byte[] _computedHash = _hashingAlg.ComputeHash(Encoding.UTF8.GetBytes($"{_password}{_salt}"));
        return Encoding.UTF8.GetString(_computedHash);
    }
    public string SaltGen()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 16)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }


}