using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Client.Services;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Client.Components
{
    public partial class ModuleData
    {
        [Parameter]
        [EditorRequired]
        public string ExtraCaption { get; set; } = string.Empty;

        [Inject]
        //public IModuleService? ModuleService { get; set; }

        public List<ModuleDTO> ModuleLst { get; set; } = new List<ModuleDTO>();

        public string responseData = string.Empty;

        public string ErrorMessage = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();

        }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal static void Add(ModuleDTO module)
        {
            throw new NotImplementedException();
        }
    }
}

