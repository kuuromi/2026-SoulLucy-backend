using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_SoulLucy_backend.Data;
using _2026_SoulLucy_backend.Models;
using _2026_SoulLucy_backend.DTOs;

namespace _2026_SoulLucy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    UserName = b.UserName,
                    RoomId = b.RoomId,
                    RoomName = b.Room != null ? b.Room.Name : "No Room",
                    Status = b.Status,
                    Date = b.Date,
                    Time = b.Time,
                    Purpose = b.Purpose
                })
                .ToListAsync();

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking(CreateBookingDto dto)
        {
            var roomExists = await _context.Rooms.AnyAsync(r => r.Id == dto.RoomId);
            if (!roomExists) return BadRequest("Ruangan tidak ditemukan.");

            var newBooking = new Booking
            {
                UserName = dto.UserName,
                RoomId = dto.RoomId,
                Status = dto.Status ?? "Pending",
                Date = dto.Date,
                Time = dto.Time,
                Purpose = dto.Purpose
            };

            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Booking berhasil dibuat!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] CreateBookingDto dto)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            var roomExists = await _context.Rooms.AnyAsync(r => r.Id == dto.RoomId);
            if (!roomExists) return BadRequest("Ruangan tujuan tidak tersedia.");

            booking.UserName = dto.UserName;
            booking.RoomId = dto.RoomId;
            booking.Date = dto.Date;
            booking.Time = dto.Time;
            booking.Purpose = dto.Purpose;

            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto dto)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            booking.Status = dto.Status;

            await _context.SaveChangesAsync();
            return Ok(new { message = $"Status diperbarui menjadi {dto.Status}" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}