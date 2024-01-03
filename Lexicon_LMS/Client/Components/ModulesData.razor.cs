using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Components
{
    public partial class ModulesData
    {
        public List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}

