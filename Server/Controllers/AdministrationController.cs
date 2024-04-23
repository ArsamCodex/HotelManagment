using HotelManagment.Server.Data;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Shared;
using System;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<AdministrationController> _logger;
        public AdministrationController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<AdministrationController> logger)
        {
            _context = context;
            hostEnvironment = environment;
            _logger = logger;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RoomInspection>> DeleteRoomInspectionArticle(int id)
        {
            try
            {
                var ArticleToDelete = await _context.roomsInspection.FirstOrDefaultAsync(e => e.RoomInspectionID == id);

                if (ArticleToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                _context.roomsInspection.Remove(ArticleToDelete);
                await _context.SaveChangesAsync();
                return Ok(ArticleToDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
           
        }

        [HttpPut("UpdateTechnical/")]
        public async Task<ActionResult> UpdateInspection( RoomInspection roomInspection)
        {
            try
            {

                var result = await _context.roomsInspection
               .FirstOrDefaultAsync(e => e.RoomInspectionID == roomInspection.RoomInspectionID);
                if (result != null)
                {
                    result.RoomNumber = roomInspection.RoomNumber;
                    result.InspectionDate = roomInspection.InspectionDate;
                    result.ProblemDescription = roomInspection.ProblemDescription;
                    result.Staff = roomInspection.Staff;
                    result.COnditions = roomInspection.COnditions;
                    result.NeedRepair = roomInspection.NeedRepair;
                    result.StartReperation = roomInspection.StartReperation;
                    result.EndReperation = roomInspection.EndReperation; 
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

        [HttpGet("GetRepaitForAdmin/{id:int}")]
        public async Task<IActionResult> AllRepaisAdmin(int id)
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
                // Log the exception for debugging purposes
                _logger.LogError(ex, "An error occurred while retrieving RoomInspection object.");

                // Return a simple error message instead of the full exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}
