using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.Data.Configurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class CalendarSerieContext :  IdentityDbContext<ApplicationUser>
    {
        public CalendarSerieContext(DbContextOptions<CalendarSerieContext> options)
            : base(options)
        {
        }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new EmisionSerieConfiguration());
            
            InitializeRolesAndUsers(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        
        private void InitializeRolesAndUsers(ModelBuilder modelBuilder)
        {
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = "ADMIN";
            var userRole = new IdentityRole("Usuario");
            userRole.NormalizedName = "USUARIO";

            modelBuilder.Entity<IdentityRole>().HasData(
                adminRole,
                userRole
            );

            var adminUser = new ApplicationUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                FirstName = "Admin",
                LastName = "Admin"
                // Otras propiedades según tus necesidades
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123*");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRole.Id }
            );
        }
    }
    
    
}