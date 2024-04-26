using HotelManagment.Server.Data;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceptionController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<AdministrationController> _logger;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ReceptionController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<AdministrationController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            hostEnvironment = environment;
            _logger = logger;
            UserManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("AddPackage")]
        public async Task<ActionResult> AddPost(Post post)
        {
            try
            {
                await _context.post.AddAsync(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AllPosts")]
        public async Task<ActionResult> AdGetAllPost()
        {
            try
            {
              var x=  await _context.post.ToListAsync();


                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
