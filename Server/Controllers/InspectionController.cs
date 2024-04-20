using HotelManagment.Server.Data;
using HotelManagment.Server.Migrations;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Shared;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspectionController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public InspectionController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            hostEnvironment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> RoomsInspection(RoomInspection  roomInspection)
        {
            try
            {
                await _context.roomsInspection.AddAsync(roomInspection);
                await _context.SaveChangesAsync();
                return Ok(roomInspection);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
    }
}
