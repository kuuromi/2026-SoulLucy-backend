using System.ComponentModel.DataAnnotations;

namespace _2026_SoulLucy_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public int RoomId { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Purpose { get; set; }
        public string Status { get; set; } = "Pending";

        public Room? Room { get; set; }
    }
}