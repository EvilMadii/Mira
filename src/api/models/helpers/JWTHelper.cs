using System.Text;
using Microsoft.Extensions.Configuration.UserSecrets;

public class JWTHelper
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public byte[] Key { get; init; }
    public JWTHelper()
    {
        IConfigurationRoot _config = new ConfigurationBuilder().AddUserSecrets<JWTHelper>().Build();
        Issuer = _config["JWT:Issuer"]!;
        Audience = _config["JWT:Audience"]!;
        Key = Encoding.UTF8.GetBytes(_config["JWT:Key"]!);
    }
}