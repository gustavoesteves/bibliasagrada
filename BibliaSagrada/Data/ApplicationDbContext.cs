using BibliaSagrada.Models.BibliaModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliaSagrada.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BibleUserDetail> BibleUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Charpter> Charpters { get; set; }
        public DbSet<Vercicle> Vercicles { get; set; }
        public DbSet<UserSavedVercicle> UserSavedVercicles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}