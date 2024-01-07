using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.AssignmetsDTOs;


namespace Lexicon_LMS.Server.Models.Profiles
{
    public class AssignmentsMapperProfile : Profile
    {
        public AssignmentsMapperProfile()
        {

            CreateMap<Assignments, AssignmentDTO>();

            //CreateMap<IEnumerable<Assignments>, AssignmentsListDTO>()
            //    .ForMember(dest => dest.ListOfAssignments, from => from.MapFrom(a => a.ToList()));
            
        }
    }
}
