using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Vetheria.Common.Config;

namespace Vetheria.Common;

public class EmailSender : IEmailSender
{
    private readonly SmtpConfig _smtpConfig;

    public EmailSender(IConfiguration configuration)
    {
        _smtpConfig = configuration.GetSection(nameof(SmtpConfig)).Get<SmtpConfig>()!;
    }

    public async Task SendAsync(EmailMessage message)
    {
        using SmtpClient client = new(_smtpConfig.Host, _smtpConfig.Port);
        client.Credentials = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);

        MailMessage mailMessage = ToMailMessage(message);

        await client.SendMailAsync(mailMessage);
    }

    private MailMessage ToMailMessage(EmailMessage message)
    {
        var fromEmail = string.IsNullOrEmpty(message.FromEmail) ? _smtpConfig.SystemEmail : message.FromEmail;
        var mail = new MailMessage(fromEmail, message.ToEmail, message.Title, message.TextBody);

        if (!string.IsNullOrEmpty(message.HtmlBody))
        {
            ContentType mimeType = new ContentType("text/html");
            var alternativeView = AlternateView.CreateAlternateViewFromString(message.HtmlBody, mimeType);
            mail.AlternateViews.Add(alternativeView);
        }

        return mail;
    }
}

