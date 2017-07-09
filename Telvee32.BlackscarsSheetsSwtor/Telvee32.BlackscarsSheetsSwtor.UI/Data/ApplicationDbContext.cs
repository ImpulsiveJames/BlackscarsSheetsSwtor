using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;
using Telvee32.BlackscarsSheetsSwtor.UI.Models;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
