namespace api.contracts.data;
public class UserDTO
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? UserProfileImageUrl { get; set; }
    public DateTime Datecreated { get; set; }
    public bool Isactive { get; set; }
}