using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.UsersDTOs;


namespace Lexicon_LMS.Server.Models.Profiles
{
    public class UsersMapperProfile : Profile
    {
        public UsersMapperProfile()
        {
            CreateMap<ApplicationUser, UserDTO>();

            //CreateMap<IEnumerable<ApplicationUser>, UserListDTO>()
            //    .ForMember(dest => dest.ListOfUsers, from => from.MapFrom(u => u.ToList()));
        }
    }
}
