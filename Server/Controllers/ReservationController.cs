using HotelManagment.Server.Data;
using HotelManagment.Server.Interface;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace HotelManagment.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public  IEmailSender _emailSender;
        private readonly IWebHostEnvironment _environment;
        public ReservationController(ApplicationDbContext context,IEmailSender emailSender, IWebHostEnvironment environment)
        {
            _context = context;
            _emailSender = emailSender;
            _environment = environment;
        }

        [HttpPost("reserve")]
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
                    RoomID = reservation.RoomID,
                    DigitalSignuture = reservation.DigitalSignuture,
                    PhoneNumber = reservation.PhoneNumber,
                    gender = reservation.gender
                    
                };

                await _context.reservation.AddAsync(reservation);
                await _context.SaveChangesAsync();

                return Ok(reservation);
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
        [HttpPost("AddRoom")]
        public async Task<IActionResult> RoomAdd([FromBody] Room room)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.rooms.AddAsync(room);
                    await _context.SaveChangesAsync();

                    // Commit the transaction if everything is successful
                    transaction.Commit();

                    return Ok(room);
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an error occurs
                    transaction.Rollback();

                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        [HttpPut("UpdateRoomDate/{id:int}")]
        public async Task<ActionResult> UpdateInspection(int id, Room room)
        {
            try
            {

                var result = await _context.rooms
               .FirstOrDefaultAsync(e => e.RoomID == room.RoomID);
                if (result != null)
                {
                    result.CheckOutDate = room.CheckOutDate;
                    await _context.SaveChangesAsync();


                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
            return null;
        }


    }

}
