using System.ComponentModel.DataAnnotations;

namespace _2026_SoulLucy_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        // Relasi ke tabel Room
        public Room? Room { get; set; }
    }
}