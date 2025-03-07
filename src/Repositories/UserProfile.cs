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
    }
}
}