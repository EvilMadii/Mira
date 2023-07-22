using api.contracts.data;
using api.repositories;
using AutoMapper;

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
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        bool result = await _repository.DeleteAsync(id);
        return result switch
        {
            true => true,
            _ => false,
        };
    }

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        var user = await _repository.GetByEmailAsync(email);
        var _userDto = _mapper.Map<UserDTO>(user);
        return _userDto;
    }

    public async Task<UserDTO?> GetByGuidAsync(Guid id)
    {
        var user = await _repository.GetAsync(id);
        var _userDto = _mapper.Map<UserDTO>(user);
        return _userDto;
    }

    public async Task<bool> UpdateAsync(UserDTO userDTO)
    {
        return await _repository.UpdateAsync(userDTO);
    }
}
