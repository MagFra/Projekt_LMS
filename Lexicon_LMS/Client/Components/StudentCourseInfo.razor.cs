using Lexicon_LMS.Shared.Domain;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        public CourseDTO CourseInfo { get; set; } = new CourseDTO();

        //public List<ModuleDTO> GetModules()
        //{
        //    //return _db
        //}

        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();
        //    ModuleInfo.Add(new Module() { Id = 2, Name="Sjöar", Description="Beskrivning", StartDate= new DateTime(), LengthOfDays=2 });


        //}

    }
}
