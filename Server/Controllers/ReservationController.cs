using HotelManagment.Server.Data;
using HotelManagment.Server.Interface;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public  IEmailSender _emailSender;
        public ReservationController(ApplicationDbContext context,IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
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
                    Staff = reservation.Staff,
                    RoomID = reservation.RoomID
                };

                await _context.reservation.AddAsync(reservationModel);
                await _context.SaveChangesAsync();

                return Ok(reservationModel);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("rooms")]
        public async Task<IActionResult> AllRooms()
        {
            try
            {
                var rooms = await _context.rooms.ToListAsync();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "An error occurred while fetching rooms.");
            }
        }
        [HttpPost("Email")]
        public async Task<IActionResult> SendEmail(EmailRequest request)
        {
            try
            {
                var email = _emailSender.SendEmailAsync(request);
                return Ok(email);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "An error occurred while fetching rooms.");
            }
        }
    }
}
