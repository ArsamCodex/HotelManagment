using HotelManagment.Shared;
using HotelManagment.Server.Interface;
using IEmailSender = HotelManagment.Server.Interface.IEmailSender;

namespace HotelManagment.Server.Helper
{
    public class EmailSchedulerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailSender _emailSender;

        public EmailSchedulerService(IServiceProvider serviceProvider, IEmailSender emailSender)
        {
            _serviceProvider = serviceProvider;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Calculate the delay until 21:50 for the current day
                TimeSpan delay = CalculateDelayUntilNext850PM();

                // Schedule the task to run at 21:50 every day
                await Task.Delay(delay, stoppingToken);

                // Perform your scheduled task here
                await SendDailyEmail();
            }
        }

        private async Task SendDailyEmail()
        {
            try
            {
                // Construct the email request
                var emailRequest = new EmailRequest
                {
                    Email = "Arminttwat@gmail.com", // Change this to the recipient's email address
                    Subject = "Daily Reminder",
                    HtmlMessage = "<p>This is a daily reminder email sent at 21:50 PM.</p>"
                };

                // Send the email
                await _emailSender.SendEmailAsync(emailRequest);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error sending daily email: {ex.Message}");
            }
        }

        private TimeSpan CalculateDelayUntilNext850PM()
        {
            DateTime now = DateTime.Now;
            DateTime next850PM = now.Date.AddHours(21).AddMinutes(50);

            if (now > next850PM)
            {
                next850PM = next850PM.AddDays(1);
            }

            return next850PM - now;
        }
    }

}
