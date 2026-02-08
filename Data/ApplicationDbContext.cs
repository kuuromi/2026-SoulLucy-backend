using Microsoft.EntityFrameworkCore;
using _2026_SoulLucy_backend.Models;

namespace _2026_SoulLucy_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
    }
}