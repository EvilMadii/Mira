using api.repositories;

namespace api.services;

class UserService : IUserService
{
    /* 
        Madi why are you creating a service for your repository 
        isn't that just an unnecessary abstraction?
        Shut your mouth and tell me I look good
    */
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

}
