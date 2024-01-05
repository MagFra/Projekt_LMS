using Duende.IdentityServer.EntityFramework.Options;
using Lexicon_LMS.Server.Models.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Lexicon_LMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Activities> activity => Set<Activities>();
        public DbSet<ApplicationUser> applicationUser => Set<ApplicationUser>();
        public DbSet<Assignments> assignments => Set<Assignments>();
        public DbSet<Courses> courses => Set<Courses>();
        public DbSet<Module> module => Set<Module>();

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Assignments>().HasKey(a => new { a.ActivityId, a.ApplicationUserId });

            builder.Entity<Courses>().HasData(
                new Courses { Id = 5, Description = "Learn the fundamentals of JavaScript programming.", LastApplicationDay = DateTime.Parse("2024-01-05"), LengthDays = 30, Name = "JavaScript", StartDate = DateTime.Parse("2024-02-01") },
                new Courses { Id = 6, Description = "Explore the world of Python and its versatile applications.", LastApplicationDay = DateTime.Parse("2024-01-10"), LengthDays = 45, Name = "Python", StartDate = DateTime.Parse("2024-02-15") },
                new Courses { Id = 7, Description = "Master Java programming for building scalable applications.", LastApplicationDay = DateTime.Parse("2024-01-15"), LengthDays = 60, Name = "Java", StartDate = DateTime.Parse("2024-03-01") },
                new Courses { Id = 8, Description = "Dive into the Ruby programming language and its elegant syntax.", LastApplicationDay = DateTime.Parse("2024-01-20"), LengthDays = 30, Name = "Ruby", StartDate = DateTime.Parse("2024-03-15") }
            );

        }

    }
}
