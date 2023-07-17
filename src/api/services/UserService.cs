using api.contracts.data;
using api.repositories;

namespace api.services;

class UserService : IUserService
{
    /* 
        Madi why are you creating a service for your repository 
        isn't that just an unnecessary abstraction?
        Shut your mouth and tell me I look good

        you can be quiet now I am using it to hold my mapping logic and stuff (I think)
    */
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO?> GetByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}
