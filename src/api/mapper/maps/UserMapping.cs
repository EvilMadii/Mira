namespace api.mapper.maps;

using api.contracts.data;
using api.models.dbEntities;
using AutoMapper;

class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>()
        .ForMember(destinationMember => destinationMember.UserId, act => act.MapFrom(sourceMember => sourceMember.UserId))
        .ForMember(destinationMember => destinationMember.UserName, act => act.MapFrom(sourceMember => sourceMember.UserName))
        .ForMember(destinationMember => destinationMember.Email, act => act.MapFrom(sourceMember => sourceMember.Email))
        .ForMember(destinationMember => destinationMember.Isactive, act => act.MapFrom(sourceMember => sourceMember.Isactive))
        .ForMember(destinationMember => destinationMember.UserProfileImageUrl, act => act.MapFrom(sourceMember => sourceMember.UserProfileImageUrl))
        .ForMember(destinationMember => destinationMember.Datecreated, act => act.MapFrom(sourceMember => sourceMember.Datecreated));

    }
}