using Duende.IdentityServer.EntityFramework.Options;
using Lexicon_LMS.Shared.Domain;
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
        public DbSet<Course> course => Set<Course>();
        public DbSet<Module> module => Set<Module>();

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
