using Duende.IdentityServer.EntityFramework.Options;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HotelManagment.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Reservation>? reservation { get; set; } = default;
        public DbSet<Room>? rooms { get; set; } = default;
        public DbSet<RoomInspection> roomsInspection { get; set; } = default;
    }
}