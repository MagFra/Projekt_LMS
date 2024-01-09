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
            //##-< Setup >-####################################################################
            db = context;

            if (db.Roles.Any()) return;

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //#################################################################################



            //##-< Seed Roles >-###############################################################
            var roleNames = new[] { "Teacher", "Student" };
            await AddRolesAsync(roleNames);
            //#################################################################################



            //##-< Seed ActivityTypes >-#######################################################
            var types = new[] { "E-learning", "Föreläsning", "Övningstillfälle", "Inlämningsuppgifter" };
            await AddActivityTypesAsync(types);
            //#################################################################################



            //##-< Seed Courses >-#############################################################
            // courses = (Description, StartDate, LengthDays, Name, LastApplicationDay)
            var courses = new (string, DateTime, int, string, DateTime)[]{
                ("Learn the fundamentals of JavaScript programming.", DateTime.Parse("2024-01-05"), 30, "JavaScript", DateTime.Parse("2024-02-01")),
                ("Explore the world of Python and its versatile applications.", DateTime.Parse("2024-01-10"), 45, "Python", DateTime.Parse("2024-02-15")),
                ("Master Java programming for building scalable applications.", DateTime.Parse("2024-01-15"), 60, "Java", DateTime.Parse("2024-03-01")),
                ("Dive into the Ruby programming language and its elegant syntax.", DateTime.Parse("2024-01-20"), 30, "Ruby", DateTime.Parse("2024-03-15"))
            };

            await AddCoursesAsync(courses);
            //#################################################################################



            //##-< Seed Modules >-#############################################################
            // modules = (CourseId, Name, Description, StartDate, LengthOfDays)
            var modules = new (int, string, string, DateTime, int)[]
            {
                (1,"Test1","dfj yhg dfkop fg rhh",DateTime.Parse("2024-01-12"),7),
                (2,"Test2","jklgh dfkjgh ifo jrh",DateTime.Parse("2024-01-12"),7)
            };
            await AddModulesAsync(modules);
            //#################################################################################



            //##-< Seed Activities >-##########################################################
            // activities = (Name, Descrition, StartDate, LenthDays, ModuleId, ActivityTypeId)
            var activities = new (string, string, DateTime, int, int, int)[] { 
                ("Test1", "jklfgheug jkgh jhg jgh dfgdf ioåhg", DateTime.Parse("2024-01-12"), 14, 1, 1),
                ("Test2", "jksdfh shuj fgkjh fjhfgh sdfjh ihd", DateTime.Parse("2024-01-12"), 14, 2, 1)
            };
            await AddActivitiesAsync(activities);
            //#################################################################################



            //##-< Seed Users >-###############################################################
            // usres = (E-mail, PassWord, FirstName, LastName, Role, CourseId)
            var users = new (string, string, string, string, string?, int?)[] {
                ("teach1@lex.se", "%T0lss1t5", "Teach1", "Teacherson", "Teacher", null),
                ("teach2@lex.se","%T0lss1t5", "Teach2", "Teachersson", "Teacher", null),
                ("student1@home.se","%T0lss1t5", "Student1", "Studentdotter", "Student", 1),
                ("student2@home.se","%T0lss1t5", "Student2", "Studentson", "Student", 2)
            };

            await AddUsersAsync(users);
            //#################################################################################


        }
        //#####################################################################################



        //##-< Seed Roles Method >-############################################################
        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            }
            await db.SaveChangesAsync();
        }
        //#####################################################################################



        //##-< Seed Users Method >-############################################################
        private static async Task AddUsersAsync((string, string, string, string, string?, int?)[] users)
        {
            string email, pw, firstName, lastName; string? role; int? courseId;

            foreach (var user in users)
            {
                (email, pw, firstName, lastName, role, courseId) = user!;
                if (await userManager.FindByEmailAsync(email) != null) continue;
                var newUser = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName,
                    CourseId = courseId,
                };
                var result = await userManager.CreateAsync(newUser, pw);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

                if (role != null)
                {
                    await AddUserToRoleAsync(newUser, role);
                }
            }
            await db.SaveChangesAsync();
        }
        //#####################################################################################



        //##-< Method to connect a User to a Role >-###########################################
        private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var result = await userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }
        //#####################################################################################



        //##-< Seed Courses Method >-#####################################################################
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
        //#####################################################################################



        //##-< Seed Modules Method >-##########################################################
        private static async Task AddModulesAsync((int, string, string, DateTime, int)[] modules)
        {
            // modules = (CourseId, Name, Description, StartDate, LengthOfDays)
            string description, name; int courseId, lengthOfDays; DateTime startDate;

            foreach (var module in modules)
            {
                (courseId,name,description,startDate,lengthOfDays) = module;
                await db.module.AddAsync(new Module
                {
                    CourseId = courseId,
                    Name = name,
                    Description = description,
                    StartDate = startDate,
                    LengthOfDays = lengthOfDays,
                });
            }
            db.SaveChanges();
        }
        //#################################################################################



        //##-< Seed ActivityTypes Method >-#####################################################################
        private static async Task AddActivityTypesAsync(string[] types)
        {
            foreach (var type in types)
            {
                await db.ActivityType.AddAsync(new ActivityType { Type = type });
            }
            await db.SaveChangesAsync();
        }
        //#################################################################################



        //##-< Seed Activities Method >-###################################################
        private static async Task AddActivitiesAsync((string, string, DateTime, int, int, int)[] activities)
        {
            // activities = (Name, Descrition, StartDate, LenthDays, ModuleId, ActivityTypeId)
            string name, description; DateTime startDate; int lengthDays, moduleId, activityTypeId;

            foreach (var activityType in activities)
            {
                (name, description, startDate, lengthDays, moduleId, activityTypeId) = activityType;
                await db.activity.AddAsync(new Activities
                {
                    Name = name,
                    Description = description,
                    StartDate = startDate,
                    LenthDays = lengthDays,
                    ModuleId = moduleId,
                    ActivityTypeId = activityTypeId
                });
            }
            await db.SaveChangesAsync();
        }
        //#################################################################################



        //##-< name >-#####################################################################
        //#################################################################################



        //##-< name >-#####################################################################
        //#################################################################################
    }
}
