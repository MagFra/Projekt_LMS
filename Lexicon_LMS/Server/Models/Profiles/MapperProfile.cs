using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain;
namespace Lexicon_LMS.Server.Models.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Activities, ActivityDTO>().ReverseMap();

            CreateMap<IEnumerable<Activities>, ActivitiesListDTO>()
                .ForMember(dest => dest.ListOfActivities, from => from.MapFrom(ac => ac.ToList()));

            CreateMap<Assignments, AssignmentDTO>().ReverseMap();

            CreateMap<IEnumerable<Assignments>, AssignmentsListDTO>()
                .ForMember(dest => dest.ListOfAssignments, from => from.MapFrom(a => a.ToList()));

            CreateMap<Courses, CourseDTO>().ReverseMap();

            CreateMap<IEnumerable<Courses>, CourseListDTO>()
                .ForMember(dest => dest.ListOfCourses, from => from.MapFrom(c => c.ToList()));

            CreateMap<Module, ModuleDTO>().ReverseMap();

            CreateMap<IEnumerable<Module>, ModuleListDTO>()
                .ForMember(dest => dest.ListOfModules, from => from.MapFrom(m => m.ToList()));

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();

            CreateMap<IEnumerable<ApplicationUser>, UserListDTO>()
                .ForMember(dest => dest.ListOfUsers, from => from.MapFrom(u => u.ToList()));
        }
    }
}
