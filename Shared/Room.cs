using HotelManagment.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class Room
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "RoomNumber is required")]
        public int? RoomNumer { get; set; }
        [Required(ErrorMessage = "HowmannyPerson is required")]
        public int? HowMannhyPersons { get; set; }
        public DateTime? CheckOutDate { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string? Image { get; set; }
        //  public Reservation reservation { get; set; }
       // public RoomInspection? roomInspection { get; set; }
    }
}