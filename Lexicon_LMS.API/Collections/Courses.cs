using Lexicon_LMS.Shared.Domain;

namespace Lexicon_LMS.API.Collections;
   public static class Courses
{
    public static List<Course> CourseList = new List<Course>()
    {
        new Course
        {
            Id = 1,
            Name = "Introduction to Programming",
            Description = "Learn the basics of programming",
            StartDate = DateTime.Now,
            LengthDays = 30,
            LastApplicationDay = DateTime.Now.AddDays(7)
        },
        new Course
        {
            Id = 2,
            Name = "Web Development Fundamentals",
            Description = "Explore the fundamentals of web development",
            StartDate = DateTime.Now.AddDays(15),
            LengthDays = 45,
            LastApplicationDay = DateTime.Now.AddDays(10)
        },
        new Course
        {
            Id = 3,
            Name = "Data Science Essentials",
            Description = "Dive into the essentials of data science",
            StartDate = DateTime.Now.AddMonths(2),
            LengthDays = 60,
            LastApplicationDay = DateTime.Now.AddMonths(2).AddDays(-5)
        },
        new Course
        {
            Id = 4,
            Name = "Advanced Machine Learning",
            Description = "Explore advanced concepts in machine learning",
            StartDate = DateTime.Now.AddMonths(3),
            LengthDays = 90,
            LastApplicationDay = DateTime.Now.AddMonths(3).AddDays(-10)
        },
        new Course
        {
            Id = 5,
            Name = "Cybersecurity Basics",
            Description = "Learn the fundamentals of cybersecurity",
            StartDate = DateTime.Now.AddMonths(1),
            LengthDays = 45,
            LastApplicationDay = DateTime.Now.AddMonths(1).AddDays(-7)
        },
        new Course
        {
            Id = 6,
            Name = "Mobile App Development",
            Description = "Explore the world of mobile app development",
            StartDate = DateTime.Now.AddDays(20),
            LengthDays = 60,
            LastApplicationDay = DateTime.Now.AddDays(15)
        },
        new Course
        {
            Id = 7,
            Name = "Cloud Computing Fundamentals",
            Description = "Get started with cloud computing",
            StartDate = DateTime.Now.AddDays(10),
            LengthDays = 30,
            LastApplicationDay = DateTime.Now.AddDays(5)
        },
    };
}
