namespace Lexicon_LMS.Shared.Domain;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; } // change from DateTime to DateTimeOffset, it can handle timezone information without issues by Xiahui.
    public int LengthDays { get; set; }
    public DateTime LastApplicationDay { get; set; }

    // Navigation properties
    public ICollection<Module> ModuleList { get; set; } = new List<Module>();
   
    public ICollection<ApplicationUser> StudentList { get; set; } = new List<ApplicationUser>();
    
}

