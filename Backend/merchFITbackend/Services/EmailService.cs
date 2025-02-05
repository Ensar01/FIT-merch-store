using merchFITbackend.Interfaces;
using System.Net;
using System.Net.Mail;

namespace merchFITbackend.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailyAsync(string email, string subject, string message)
        {
            var mail = "fitmerchstore.noreply@gmail.com";
            var pw = "qmjppcrjphydvqmz";
            

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from:mail,
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
