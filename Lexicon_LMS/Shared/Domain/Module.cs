using System;

namespace Lexicon_LMS.Shared.Domain;

public class Module
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public int? LengthOfDays { get; set; }

    // Constructor to initialize the class with a start date and a time duration
    public Module(int id, int courseId, string name, string description, DateTime startDate, int? lengthOfDays)
    {
        Id = id;
        CourseId = courseId;
        Name = name;
        Description = description;
        StartDate = startDate;
        LengthOfDays = lengthOfDays;
    }

    // Method to calculate the end date based on the start date and time duration
    public DateTime? CalculateEndDate()
    {
        if (LengthOfDays.HasValue)
        {
            return StartDate.AddDays(LengthOfDays.Value);
        }

        return null; // Return null if LengthOfDays is not specified
    }
    // Calculate LengthOfDays based on StartDate and EndDate
    public void CalculateLengthOfDays(DateTime endDate)
    {
        LengthOfDays = (int)(endDate - StartDate).TotalDays;
    }
}
