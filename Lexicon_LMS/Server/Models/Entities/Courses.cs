﻿namespace Lexicon_LMS.Server.Models.Entities;

public class Courses
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public int LengthDays { get; set; }
    public DateTime LastApplicationDay { get; set; }

    // Navigation properties
    public ICollection<Module>? ModuleList { get; set; } = null!;
   
    public ICollection<ApplicationUser>? StudentList { get; set; } = null!;
    
}

