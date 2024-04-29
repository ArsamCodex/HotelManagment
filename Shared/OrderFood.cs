using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class OrderFood
    {
        public int OrderFoodId { get; set; }
        public int   roomNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderedFood { get; set; }
    }
}
