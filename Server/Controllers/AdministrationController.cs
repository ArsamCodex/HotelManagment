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

        public AdministrationController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            hostEnvironment = environment;
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
    }
}
