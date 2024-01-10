using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;


namespace Lexicon_LMS.Server.Models.Profiles
{
    public class CoursesMapperProfile : Profile
    {
        public CoursesMapperProfile()
        {
            CreateMap<Courses, CourseDTO>();

            CreateMap<Courses, CourseLimitedDTO>();

            //CreateMap<IEnumerable<Courses>, CourseListDTO>()
            //    .ForMember(dest => dest.ListOfCourses, from => from.MapFrom(c => c.ToList()));
        }
    }
}
