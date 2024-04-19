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
        public int RoomNumer { get; set; }
        public Reservation reservation { get; set; }
    }
}
