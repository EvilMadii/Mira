using api.contracts.data;
using api.models.dbEntities;
public static class UserToDTOMapper
{
    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            UserProfileImageUrl = user.UserProfileImageUrl,
            Datecreated = user.Datecreated,
            Isactive = user.Isactive
        };
    }
}