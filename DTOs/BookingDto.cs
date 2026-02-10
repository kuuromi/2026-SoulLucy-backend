namespace _2026_SoulLucy_backend.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Purpose { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Facilities { get; set; } = string.Empty;
    }
}