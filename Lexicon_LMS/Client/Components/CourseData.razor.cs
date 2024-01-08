using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Client.Services;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;

namespace Lexicon_LMS.Client.Components
{
    public partial class CourseData
    {
        [Parameter]
        [EditorRequired]
        public string ExtraCaption { get; set; } = string.Empty;

        [Inject]
        public ICourseService? CourseService { get; set; }

        public List<CourseDTO> CourseLst { get; set; } = new List<CourseDTO>();

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

        internal static void Add(CourseDTO course)
        {
            throw new NotImplementedException();
        }
    }
}

