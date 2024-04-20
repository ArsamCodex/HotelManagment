using HotelManagment.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class Room
    {
        public int RoomID { get; set; }
        public int? RoomNumer { get; set; }
        public int? HowMannhyPersons { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string? Image { get; set; }
      //  public Reservation reservation { get; set; }
    }
}