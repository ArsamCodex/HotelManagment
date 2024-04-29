using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class Kitchen
    {
        public int KitchenId { get; set; }
        public string ProblemsInitchen { get; set; }
        public string MissingIngredients { get; set; }
        public DateTime ReportDate { get; set; }
        public string Staff { get; set; }
       // public int FoodMenuId { get; set; }
      //  public FoodMenu? FoodMenu { get; set; } = new FoodMenu();
    }
}
