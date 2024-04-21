using HotelManagment.Shared;
using System.ComponentModel.DataAnnotations;

namespace HotelManagment.Server.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
      //  public Room room { get; set; }
        public int RoomID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Adress is required")]
        public string? Adress { get; set; }
        public int? HowManyPerosn { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReserved { get; set; }
        public double? Amount { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string? PhoneNumber { get; set; }
        public string? Staff { get; set; }
        public string? DigitalSignuture { get; set; }
    }
}
