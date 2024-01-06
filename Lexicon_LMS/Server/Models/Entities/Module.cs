
namespace Lexicon_LMS.Server.Models.Entities;

public class Module
{
    public int Id { get; set; }
    public int? CourseId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public int? LengthOfDays { get; set; }

    public ICollection<Activities> Activities { get; set; } = null!;

    public Courses Course { get; set; } = null!;


}