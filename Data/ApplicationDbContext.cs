using Microsoft.EntityFrameworkCore;
using _2026_SoulLucy_backend.Models;

namespace _2026_SoulLucy_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Ruang Kelas A",
                    Capacity = 30,
                    Facilities = "AC, Whiteboard, Proyektor, Wi-Fi",
                    Status = "Available"
                },
                new Room
                {
                    Id = 2,
                    Name = "Ruang Kelas B",
                    Capacity = 120,
                    Facilities = "AC, Sound System, Proyektor, Wi-Fi",
                    Status = "Available"
                },
                new Room
                {
                    Id = 3,
                    Name = "Computer Laboratorium",
                    Capacity = 30,
                    Facilities = "30 unit PC, AC, LAN, Proyektor",
                    Status = "In Use"
                },
                new Room
                {
                    Id = 4,
                    Name = "Mini Theater",
                    Capacity = 50,
                    Facilities = "Dolby Atmos, Recliner Seats, Peredam Suara",
                    Status = "Available"
                },
                new Room
                {
                    Id = 5,
                    Name = "Auditorium",
                    Capacity = 200,
                    Facilities = "Grand Stage, Sound System, Kapasitas Besar, AC",
                    Status = "Available"
                }
            );
        }
    }
}