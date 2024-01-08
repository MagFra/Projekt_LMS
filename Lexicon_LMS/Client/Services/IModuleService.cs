using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Services
{
    public interface IModuleService
    {
        List<ModuleDTO> GetModules();

        CourseDTO GetModule(int Id);

        //void DeleteCourse(int Id);

        //void UpdateCourse(CourseDTO Course);

        void AddModule(ModuleDTO Course);
    }
}