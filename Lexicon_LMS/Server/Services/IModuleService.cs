using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Services
{
    public interface IModuleService
    {
        Task<ModuleDTO> AddModuleAsync(ModuleForCreationDTO dto);
        void DeleteModuleAsync(int moduleId);
        Task<ModuleDTO> GetModuleAsync(int moduleId);
        Task<IEnumerable<ModuleDTO>> GetModuleListAsync(int? corseId = null);
        Task<bool> UpdateModuleAsync(int id,ModuleForUpdateDTO dto);
    }
}