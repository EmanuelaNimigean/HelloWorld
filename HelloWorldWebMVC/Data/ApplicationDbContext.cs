using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWebMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorldWebMVC.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWebMVC.Models.TeamMember> TeamMembers { get; set; }
    }
}
