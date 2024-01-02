﻿using Lexicon_LMS.Shared.Domain;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        public Course CourseInfo { get; set; } = new Course();

        public List<Module> ModuleInfo { get; set; } = new List<Module>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ModuleInfo.Add(new Module() { Id = 2, Name="Sjöar", Description="Beskrivning", StartDate= new DateTime(), LengthOfDays=2 });


        }

    }
}
