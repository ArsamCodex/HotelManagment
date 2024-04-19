using HotelManagment.Shared;

namespace HotelManagment.Server.Interface
{
    public interface IEmailSender
    {
        public  Task SendEmailAsync(EmailRequest emailreqquest);
    }

}
