namespace merchFITbackend.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailyAsync(string email, string subject, string message);
    }
}
