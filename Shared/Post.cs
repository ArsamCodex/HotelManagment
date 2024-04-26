using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class Post
    {
       
            public int PostID { get; set; }

            [Required(ErrorMessage = "Barcode is required")]
            public string Barcode { get; set; }

            [Required(ErrorMessage = "Received Time is required")]
            public DateTime ReceivedTime { get; set; }

            [Required(ErrorMessage = "For Which Room is required")]
            public int ForWhichRoom { get; set; }

        public string StaffId { get; set; }

        // Navigation property for the related Reception
    }
}
