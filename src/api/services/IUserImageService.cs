namespace api.services;
public interface IUserImageService
{
    public Task<bool> UpdateUserProfilePictureAsync(Guid _uuid, string _uri);
    public Task<bool> ResetUserProfilePicAsync(Guid _uuid);
}