using HotelManagment.Server.Data;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Admins
    public class SendMessageController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<AdministrationController> _logger;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SendMessageController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<AdministrationController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            hostEnvironment = environment;
            _logger = logger;
            UserManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("SendMessaget/")]
        public async Task<ActionResult<SendMessage>> SendMessageto(SendMessage sendMessage)
        {
            try
            {
                await _context.sendMessage.AddAsync(sendMessage);
                await _context.SaveChangesAsync();
                return Ok(sendMessage);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
