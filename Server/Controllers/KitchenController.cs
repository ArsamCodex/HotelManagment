using HotelManagment.Server.Data;
using HotelManagment.Server.Models;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KitchenController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly ILogger<AdministrationController> _logger;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public KitchenController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<AdministrationController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _logger = logger;
            UserManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("TodayFoodMenu")]
        public async Task<ActionResult> FoodMenjuItems(FoodMenuDto foodMenuDto)
        {
            try
            {
                var foodMenu = new FoodMenu
                {
                    FoodMenuId = foodMenuDto.FoodMenuId,
                    Option1 = foodMenuDto.Option1,
                    Option2 = foodMenuDto.Option2,
                    Option3 = foodMenuDto.Option3,
                    TodayFood = foodMenuDto.TodayFood

                };
                await _context.fooMenu.AddAsync(foodMenu);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("KitchenProblemToAdmin")]
        public async Task<ActionResult> KitchenProbForAdministration(Kitchen kitchen)
        {
            try
            {

                await _context.kitchen.AddAsync(kitchen);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
