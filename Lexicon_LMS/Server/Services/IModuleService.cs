using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Services
{
    public interface IModuleService
    {
        Task<ModuleDTO> AddModuleAsync(ModuleForCreationDTO dto);
        Task<bool> DeleteModuleAssync(int moduleId);
        Task<ModuleDTO?> GetModuleAsync(int moduleId);
        Task<IEnumerable<ModuleDTO>?> GetModuleListAsync(int? corseId = null);
        Task<bool> UpdateModuleAssync(int id,ModuleForUpdateDTO dto);
    }
}