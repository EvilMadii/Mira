using api.contracts.data;
using api.models.dbEntities;
namespace api.repositories;

interface IUserRepository
{
    Task<User?> GetAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(UserDTO userDTO);
    Task<bool> DeleteAsync(Guid id);

}