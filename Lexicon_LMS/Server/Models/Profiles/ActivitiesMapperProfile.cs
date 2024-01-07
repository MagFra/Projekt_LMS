using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;


namespace Lexicon_LMS.Server.Models.Profiles
{
    public class ActivitiesMapperProfile : Profile
    {
        public ActivitiesMapperProfile()
        {

            CreateMap<Activities, ActivityDTO>();

            //CreateMap<IEnumerable<Activities>, ActivitiesListDTO>()
            //    .ForMember(dest => dest.ListOfActivities, from => from.MapFrom(ac => ac.ToList()));

           
        }
    }
}
