using api.contracts.data;
using api.dal;
using api.models.dbEntities;
using Microsoft.EntityFrameworkCore;
namespace api.repositories;

class UserRepository : IUserRepository
{
    private readonly RailwayContext _context;
    public UserRepository()
    {
        _context = new RailwayContext();
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
        if (user is null)
            return false;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        if (await _context.Users.AnyAsync(u => u.UserId == id))
            return false;

        return true;
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
    public Task<bool> UpdateAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}