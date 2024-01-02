using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.API.Endpoints;

public static class Courses
{
    public static void RegisterUserEndpoint(this IEndpointRouteBuilder routes)
    {
        var courses = routes.MapGroup("");
       
        // // Map the "/api/courses" endpoint
        // courses.MapGet("/courses", () =>
        // {
        //     if (Collections.Courses.CourseList != null &&
        //         Collections.Courses.CourseList.Count > 0)
        //     {
        //         return Results.Ok(Collections.Courses.CourseList);
        //     }
        //     else
        //     { 
        //         return Results.StatusCode(404);
        //     }
        // });

        // courses.MapGet("/course/{Id}",
        //     (int Id) =>
        //     {
        //         var course = Collections.Courses.CourseList
        //             .FirstOrDefault(course => course.Id == Id);

        //         if (course != null)
        //         {
        //             return Results.Ok(course);
        //         }
        //         else
        //         {
        //             return Results.StatusCode(1); // 1 = not found
        //         }
        //     });

        // courses.MapPost("/course/add", (Course course) =>
        // {
        //     course.Id = Collections.Courses.CourseList.Count + 1;

        //     Collections.Courses.CourseList.Add(course);

        //     return Results.Created($"/course/{course.Id}", course);
        // });
            
            // Api using dbContext to get all courses
            courses.MapGet("/courses", async context =>
            {
                var courseList = await dbContext.course.ToListAsync(); // Updated to use dbContext.course

                if (courseList != null && courseList.Count > 0)
                {
                    await context.Response.WriteAsJsonAsync(courseList);
                }
                else
                {
                    context.Response.StatusCode = 404;
                }
            });

            courses.MapGet("/course/{Id}", async context =>
            {
                if (int.TryParse(context.Request.RouteValues["Id"]?.ToString(), out int id))
                {
                    var course = await dbContext.course.FirstOrDefaultAsync(course => course.Id == id); // Updated to use dbContext.course

                    if (course != null)
                    {
                        await context.Response.WriteAsJsonAsync(course);
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                    }
                }
                else
                {
                    context.Response.StatusCode = 400; // Bad Request
                }
            });

            courses.MapPost("/course/add", async context =>
            {
                var course = await context.Request.ReadFromJsonAsync<Course>();

                if (course != null)
                {
                    dbContext.course.Add(course); // Updated to use dbContext.course
                    await dbContext.SaveChangesAsync();

                    context.Response.StatusCode = 201; // Created
                    context.Response.Headers["Location"] = $"/course/{course.Id}";
                }
                else
                {
                    context.Response.StatusCode = 400; // Bad Request
                }
            });
    }
}
