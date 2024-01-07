using AutoMapper;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;


namespace Lexicon_LMS.Server.Models.Profiles
{
    public class ModulesMapperProfile : Profile
    {
        public ModulesMapperProfile()
        {
            CreateMap<Module, ModuleDTO>();

            CreateMap<ModuleForCreationDTO, Module>();

            CreateMap<ModuleForUpdateDTO, Module>();

            //CreateMap<IEnumerable<Module>, ModuleListDTO>()
            //    .ForMember(dest => dest.ListOfModules, from => from.MapFrom(m => m.ToList()));
        }
    }
}
