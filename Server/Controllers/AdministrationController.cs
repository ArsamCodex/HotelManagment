using HotelManagment.Server.Data;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Shared;
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HotelManagment.Client.Pages;
using HotelManagment.Server.Models;
using HotelManagment.Client.DTos;
using static Duende.IdentityServer.Models.IdentityResources;

namespace HotelManagment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<AdministrationController> _logger;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AdministrationController(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<AdministrationController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            hostEnvironment = environment;
            _logger = logger;
            UserManager = userManager;
            _roleManager = roleManager;
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
        public async Task<ActionResult> UpdateInspection(RoomInspection roomInspection)
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
        /*
        [HttpPost("ChnageRoleByAdmin")]
        public async Task<IActionResult> ChangeRole(string UserID,string SelectedRole)
        {
            var user = await UserManager.FindByIdAsync(UserID);
            // Check if the selected role exists
            var roleExists = await RoleManager.RoleExistsAsync(SelectedRole);
            var userRoles = await UserManager.GetRolesAsync(user);
            await UserManager.RemoveFromRolesAsync(user, userRoles);

            // Add the user to the selected role
            await UserManager.AddToRoleAsync(user, SelectedRole);
            return Ok(user);
        }*/
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAsync()
        {
            var users = await UserManager.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAdmin(string id)
        {
            try
            {
                var technicalProb = await _context.Users.FirstOrDefaultAsync(d => d.Id == id);
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

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUsers(UserDto user)
        {
            try
            {

                var result = await _context.Users
               .FirstOrDefaultAsync(e => e.Id == user.Id);
                if (result != null)
                {
                    result.UserName = user.UserName;
                    result.NormalizedUserName = user.NormalizedUserName;
                    result.Email = user.Email;
                    result.NormalizedEmail = user.NormalizedEmail;
                    result.EmailConfirmed = user.EmailConfirmed;
                    result.PhoneNumber = user.PhoneNumber;
                    result.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                    result.TwoFactorEnabled = user.TwoFactorEnabled;
                    result.LockoutEnabled = user.LockoutEnabled;
                    result.LockoutEnd = user.LockoutEnd;
                    await _context.SaveChangesAsync();


                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
            return Ok(user);
        }
        [HttpGet("SearchUsers")]
        public async Task<IActionResult> GetSearchUser(string search)
        {
            try
            {
                // Retrieve all users from the UserManager
                var users = await UserManager.Users.ToListAsync();

                // Convert search term to lowercase for case-insensitive search

                // Filter users whose email contains the search term
                users = users.Where(u => u.Email.ToLower().Contains(search)).ToList();


                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }
        [HttpGet("GetUserByIdRoles/{id}")]
        public async Task<IActionResult> GetUserByIdAdminRoles(string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);

                if (user == null)
                {
                    return NotFound(); // Return 404 Not Found if user with the given id is not found
                }

                var userRoles = await UserManager.GetRolesAsync(user);
                var currentRole = userRoles.FirstOrDefault();
                return Ok(currentRole);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                _logger.LogError(ex, "An error occurred while retrieving user roles by ID.");

                // Return a simple error message instead of the full exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet("GetUserByIdInclude/{id}")]
        public async Task<ActionResult<UserDtoFOrAdmin>> GetUserByIdAdminInclude(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User id cannot be null or empty.");
            }

            var user2 = await (from user in _context.Users
                              join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                              join role in _context.Roles on userRoles.RoleId equals role.Id
                              where user.Id == id  // Filter by user id
                              select new UserDtoFOrAdmin
                              {
                                  UserId = user.Id,
                                  UserEmail = user.Email,
                                 EmailConfirmed= user.EmailConfirmed,
                                 PasswordHash= user.PasswordHash,
                                  UserPhone = user.PhoneNumber,
                                 PhoneNumberConfirmed= user.PhoneNumberConfirmed,
                                TwoFactorEnabled=  user.TwoFactorEnabled,
                                  RoleName = role.Name
                              })
                        .FirstOrDefaultAsync();  // Retrieve the first matching user or null if not found

            if (user2 == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user2);
        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllRoles()
        {
            var roleNames = await _roleManager.Roles
        .Select(r => r.Name)
        .ToListAsync();
            return Ok(roleNames);
        }
        [HttpPost("ChangeRoleAdmin/{role}/{userid}")]
        public async Task<ActionResult> ChangeRolesAdmin(string role, string userid)
        {
            var user = await UserManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound($"User with ID '{userid}' not found.");
            }

            // Check if the selected role exists
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return NotFound($"Role '{role}' not found.");
            }

            var userRoles = await UserManager.GetRolesAsync(user);
            await UserManager.RemoveFromRolesAsync(user, userRoles);

            // Add the user to the selected role
            await UserManager.AddToRoleAsync(user, role);

            return Ok();
        }

    }
}
