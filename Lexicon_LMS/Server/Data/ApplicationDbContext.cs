using Duende.IdentityServer.EntityFramework.Options;
using Humanizer;
using Lexicon_LMS.Server.Models.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Emit;

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

            // Configure the one-to - many relationship between Courses and Module
            builder.Entity<Courses>()
            .HasMany(c => c.ModuleList)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Lexicon_LMS.Server.Models.Entities.ActivityType> ActivityType { get; set; } = default!;

    }
}
