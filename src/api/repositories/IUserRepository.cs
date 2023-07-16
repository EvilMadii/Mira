using api.contracts.data;

namespace api.repositories;

interface IUserRepository
{
    Task<UserDTO?> GetAsync(Guid id);
    Task<UserDTO?> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(UserDTO userDTO);
    Task<bool> DeleteAsync(Guid id);
    
}