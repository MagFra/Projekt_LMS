using Lexicon_LMS.Shared.Domain;

namespace Lexicon_LMS.Server.Services
{
    public interface IModuleService
    {
        Task<ModuleDTO> AddModuleAsync(ModuleForCreationDTO dto);
        void DeleteModuleAssync(int moduleId);
        Task<ModuleDTO> GetModuleAsync(int moduleId);
        Task<ModuleListDTO> GetModuleListAsync(int? corseId = null);
        void UpdateModuleAssync(ModuleForUpdateDTO dto);
    }
}