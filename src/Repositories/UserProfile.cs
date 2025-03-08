using AutoMapper;
using Domain.Models;

namespace Repositories
{
    public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Domain.Entities.User, UserModel>();
        CreateMap<UserModel, Domain.Entities.User>();
        CreateMap<RoleModel, Domain.Entities.Role>();
        CreateMap<Domain.Entities.Role, RoleModel>();
    }
}
}