using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Services
{
    public interface IModuleServiceClient
    {
        List<ModuleDTO> GetModules();

        ModuleDTO GetModule(int Id);

        //void DeleteCourse(int Id);

        //void UpdateCourse(CourseDTO Course);

        void AddModule(ModuleDTO Module);
    }
}
