namespace Vetheria.Common;

public interface IEmailSender
{
    Task SendAsync(EmailMessage message);
}