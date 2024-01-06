using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Shared.Domain;
using Lexicon_LMS.Server.Models.Entities;

namespace Lexicon_LMS.Server.Data
{
    public class SeedData
    {
        public static ApplicationDbContext db = default!;
        public static UserManager<ApplicationUser> userManager = default!;
        public static RoleManager<IdentityRole> roleManager = default!;

        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services)
        {
            db = context;

            if (db.Roles.Any()) return;

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var roleNames = new[] { "Teacher", "Student" };
            await AddRolesAsync(roleNames);

            var users = new (string, string, string, string, string?)[] {
                ("teach1@lex.se", "%T0lss1t5", "Teach1", "Teacherson", "Teacher"),
                ("teach2@lex.se","%T0lss1t5", "Teach2", "Teachersson", "Teacher"),
                ("student1@home.se","%T0lss1t5", "Student1", "Studentdotter", "Student"),
                ("student2@home.se","%T0lss1t5", "Student2", "Studentson", "Student")
            };

            await AddUsersAsync(users);

            var courses = new (string, DateTime, int, string, DateTime)[]{
                ("Learn the fundamentals of JavaScript programming.", DateTime.Parse("2024-01-05"), 30, "JavaScript", DateTime.Parse("2024-02-01")),
                ("Explore the world of Python and its versatile applications.", DateTime.Parse("2024-01-10"), 45, "Python", DateTime.Parse("2024-02-15")),
                ("Master Java programming for building scalable applications.", DateTime.Parse("2024-01-15"), 60, "Java", DateTime.Parse("2024-03-01")),
                ("Dive into the Ruby programming language and its elegant syntax.", DateTime.Parse("2024-01-20"), 30, "Ruby", DateTime.Parse("2024-03-15"))
            };

            await AddCoursesAsync(courses);
        }

        //#####################################################################################

        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            }
        }

        //#####################################################################################

        private static async Task AddUsersAsync((string, string, string, string, string?)[] users)
        {
            string email, pw, firstName, lastName; string? role;

            foreach (var user in users)
            {
                (email, pw, firstName, lastName, role) = user!;
                if (await userManager.FindByEmailAsync(email) != null) continue;
                var newUser = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName,
                };
                var result = await userManager.CreateAsync(newUser, pw);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

                if (role != null)
                {
                    await AddUserToRoleAsync(newUser, role);
                }
            }
        }

        //#####################################################################################

        private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var result = await userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        //#####################################################################################

        private static async Task AddCoursesAsync((string, DateTime, int, string, DateTime)[] courses)
        {
            string description, name; DateTime lastApplicationDay, startDate; int lenthDays;
            foreach (var course in courses)
            {
                (description, lastApplicationDay, lenthDays, name, startDate) = course;
                await db.courses.AddAsync(new Courses
                {
                    Description = description,
                    Name = name,
                    LastApplicationDay = lastApplicationDay,
                    StartDate = startDate,
                    LengthDays = lenthDays
                });
            }
            await db.SaveChangesAsync();
        }
    }
}
