using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Components
{
    public partial class CourseData
    {
        public List<CourseDTO> Course { get; set; } = new List<CourseDTO>();

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            base.OnInitialized();

        }
    }
}

