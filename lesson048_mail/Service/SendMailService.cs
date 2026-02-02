using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

public class SendMailService
{
    private readonly MailSettings _mailSettings;

    public SendMailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
        email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        email.To.Add(new MailboxAddress("Ten nguoi nhan", mailContent.To));
        email.Subject = mailContent.Subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = mailContent.Body;
        // builder.Attachments
        // builder.TextBody

        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
            return "GUI THANH CONG";
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return $"Loi: {e.Message}";
        }
    }
}

public class MailContent
{
    public string To { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;
}