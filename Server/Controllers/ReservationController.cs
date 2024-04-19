using HotelManagment.Server.Data;
using HotelManagment.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async  Task< IActionResult> CreateReservation([FromBody] Reservation reservation )
        {
            Reservation reservationModel = new Reservation()
            {
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Adress = reservation.Adress,
                Email = reservation.Email,
                HowManyPerosn = reservation.HowManyPerosn,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                IsPaid = reservation.IsPaid,
                Amount = reservation.Amount,
                Staff = reservation.Staff
            };
            _context.reservation.Add(reservationModel);
            await _context.SaveChangesAsync();
            return Ok(reservationModel);
            
        }
    }
}
