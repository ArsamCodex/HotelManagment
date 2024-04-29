using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class FoodMenu
    {
        public int FoodMenuId { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public DateTime? TodayFood { get; set; }
       // public Kitchen Kitchen { get; set; }
    }
}
