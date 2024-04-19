using System.Net.Mail;
using System.Net;
using HotelManagment.Shared;

namespace HotelManagment.Server.Interface
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  Task SendEmailAsync(EmailRequest request)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            var mail = emailSettings["EmailAddress"];
            var pass = emailSettings["Password"];
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pass)
            };
            return client.SendMailAsync(

                new MailMessage(from: mail,
                to: request.Email,
                request.Subject,
                request.HtmlMessage



               ));
        }
    }
}
