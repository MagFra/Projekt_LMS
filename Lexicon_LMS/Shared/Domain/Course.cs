namespace Lexicon_LMS.Shared.Domain;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public int LengthDays { get; set; }
    public DateTime LastApplicationDay { get; set; }

    // Foreign key
    public int ModuleId { get; set; }

    // Navigation property
    public ICollection<Module> Modules { get; set; } = new List<Module>();
    
}

