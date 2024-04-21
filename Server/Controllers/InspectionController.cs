using HotelManagment.Server.Data;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Shared;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> RoomsInspection(RoomInspection roomInspection)
        {
            try
            {
                await _context.roomsInspection.AddAsync(roomInspection);
                await _context.SaveChangesAsync();
                return Ok(roomInspection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("RoomRepair")]
        public async Task<IActionResult> GetALlRoomInspectionsToTakeAction()
        {
            try
            {
                var inspections = await _context.roomsInspection
                    .Where(c => c.NeedRepair == true)
                    .ToListAsync();

                return Ok(inspections);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("technical-problems/{id:int}")]
        public async Task<IActionResult> GetTechnicalProblemById(int id)
        {
            try
            {
                var technicalProb = await _context.roomsInspection.FirstOrDefaultAsync(d => d.RoomInspectionID == id);
                if (technicalProb == null)
                {
                    return NotFound(); // Return 404 Not Found if no technical problem with the given id is found
                }

                return Ok(technicalProb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("repairStarts")]
        public async Task<IActionResult> RepaiStart(Repair repair)
        {
            try
            {
                await _context.repair.AddAsync(repair);
                await _context.SaveChangesAsync();
                return Ok(repair);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("GetStartedRepairs/{id:int}")]
        public async Task<IActionResult> StartedRepairs(int id)
        {
            try
            {
                var technicalProb = await _context.repair.FirstOrDefaultAsync(d => d.RoomNumberrepair == id);
                if (technicalProb == null)
                {
                    return NotFound(); // Return 404 Not Found if no technical problem with the given id is found
                }

                return Ok(technicalProb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("AllInspections")]
        public async Task<IActionResult> GetAllInspectionRooms()
        {
            try
            {
                var inspections = await _context.roomsInspection
                    .ToListAsync();

                return Ok(inspections);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}