namespace Vetheria.Common;

public class EmailMessage
{
    public string Title { get; set; } = string.Empty;
    public string TextBody { get; set; } = string.Empty;
    public string? HtmlBody { get; set; }
    public string? FromEmail { get; set; }
    public string ToEmail { get; set; } = string.Empty;

    public bool IsHtml
    {
        get
        {
            return !string.IsNullOrEmpty(HtmlBody);
        }
    }

    private EmailMessage(string title, string textBody, string? htmlBody, string? fromEmail, string toEmail)
    {
        Title = title;
        TextBody = textBody;
        HtmlBody = htmlBody;
        FromEmail = fromEmail;
        ToEmail = toEmail;
    }

    public static EmailMessage NewTextEmail(string title, string textBody, string? fromEmail, string toEmail)
    {
        return new EmailMessage(title, textBody, null, fromEmail, toEmail);
    }

    public static EmailMessage NewHtmlEmail(string title, string textBody, string htmlBody, string? fromEmail, string toEmail)
    {
        return new EmailMessage(title, textBody, htmlBody, fromEmail, toEmail);
    }

    public static EmailMessage NewHtmlEmail(string title, string textBody, string htmlBody, string toEmail)
    {
        return new EmailMessage(title, textBody, htmlBody, null, toEmail);
    }
    public static EmailMessage NewHtmlEmail(string title, string htmlBody, string toEmail)
    {
        return new EmailMessage(title, "Please switch to HTML email content.", htmlBody, null, toEmail);
    }
}

