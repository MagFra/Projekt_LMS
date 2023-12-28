
namespace Lexicon_LMS.Shared.Domain;

public class Module
{
    public int Id { get; set; }
    public int? CourseId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public int? LengthOfDays { get; set; }

}