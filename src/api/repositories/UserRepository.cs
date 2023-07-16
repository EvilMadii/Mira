using api.contracts.data;
using api.dal;

namespace api.repositories;

class UserRepository : IUserRepository
{
    private readonly RailwayContext _context;
    public UserRepository()
    {
        _context = new RailwayContext();
    }
    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}