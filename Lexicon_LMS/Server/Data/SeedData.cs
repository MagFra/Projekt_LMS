using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Shared.Domain;

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
    }
}
