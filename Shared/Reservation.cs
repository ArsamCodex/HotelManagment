using HotelManagment.Shared;

namespace HotelManagment.Server.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public Room room { get; set; }
        public int RoomID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int HowManyPerosn { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReserved { get; set; }
        public double Amount { get; set; }
        public string Staff { get; set; }
        public int DigitalSignuture { get; set; }
    }
}
