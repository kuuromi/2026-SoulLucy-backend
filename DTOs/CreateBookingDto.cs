using System.ComponentModel.DataAnnotations;

namespace _2026_SoulLucy_backend.DTOs
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Nama peminjam harus diisi")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Pilih ruangan terlebih dahulu")]
        public int RoomId { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Purpose { get; set; }
        public string Status { get; set; } = "Pending";
    }
}