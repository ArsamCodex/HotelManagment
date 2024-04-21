using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class Repair
    {
        public int RepairID { get; set; }
        public DateTime ReperationStart { get; set; }
        public DateTime? ReperationEnd { get; set; }
        public bool? IsAllProblemSolved { get; set; }
        public int RoomNumberrepair { get; set; }
        public string staff { get; set; }

    }
}
