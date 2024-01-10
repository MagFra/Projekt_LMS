using Lexicon_LMS.Client.Components;
using Lexicon_LMS.Client.Pages;
using Lexicon_LMS.Server.Services;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Services
{
    public class ModuleServiceClient : IModuleServiceClient
    {
        public static List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
        public ModuleServiceClient()
        {

        }
        public List<ModuleDTO> GetModules()
        {
            return Modules;
        }

        public ModuleDTO GetModule(int Id)
        {
            return Modules.FirstOrDefault(x => x.Id == Id)!;
        }

        public ModuleDTO GetDevice(int Id)
        {
            return Modules.FirstOrDefault(x => x.Id == Id)!;
        }
        public void AddModule(ModuleDTO module)
        {
            Random rnd = new Random();
            module.Id = rnd.Next(100000);
            ModuleData.Add(module);
        }
    }
}
