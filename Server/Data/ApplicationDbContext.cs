using Duende.IdentityServer.EntityFramework.Options;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelManagment.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public ApplicationDbContext(
            DbContextOptions options,

            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)

        {

        }
        public DbSet<Reservation> reservation { get; set; } = default;
        public DbSet<Room> rooms { get; set; } = default;
        public DbSet<RoomInspection> roomsInspection { get; set; } = default;
        public DbSet<Repair> repair { get; set; } = default;
        public DbSet<Post> post { get; set; } = default;
        public DbSet<SendMessage> sendMessage { get; set; } = default;

        public DbSet<FoodMenu> fooMenu { get; set; } = default;
        public DbSet<Kitchen> kitchen { get; set; } = default;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Create initial user and role
            SeedInitialData(modelBuilder);
        
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Seed default role
            const string defaultRoleName = "admin";
            var role = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = defaultRoleName, NormalizedName = defaultRoleName.ToUpper() };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Seed new user
            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "newuser@example.com",
                NormalizedUserName = "NEWUSER@EXAMPLE.COM",
                Email = "newuser@example.com",
                NormalizedEmail = "NEWUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "YourPasswordHashHere", // Replace this with the hashed password
                SecurityStamp = Guid.NewGuid().ToString()
            };
            modelBuilder.Entity<ApplicationUser>().HasData(newUser);

            // Assign default role to the new user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = newUser.Id
            });
        }

    }
}


