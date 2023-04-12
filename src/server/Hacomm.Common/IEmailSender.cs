namespace Hacomm.Common;

public interface IEmailSender
{
    Task SendAsync(EmailMessage message);
}