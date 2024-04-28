using HotelManagment.Server.Controllers;
using HotelManagment.Server.Data;
using HotelManagment.Server.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HotemManagmentTest
{
    public class UnitTest1
    {
        public readonly ApplicationDbContext _context;
        public IEmailSender _emailSender;
        private readonly IWebHostEnvironment _environment;
        [Fact]
        public void Test1()
        {
            var TestController  = new ReservationController(_context, _emailSender, _environment);
   
        }
    }
}