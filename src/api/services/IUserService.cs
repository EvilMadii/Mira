using api.contracts.data;

namespace api.services;

public interface IUserService
{

    Task<UserDTO?> GetByGuidAsync(Guid id);
    Task<UserDTO?> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(UserDTO userDTO);
    Task<bool> DeleteAsync(Guid id);


}