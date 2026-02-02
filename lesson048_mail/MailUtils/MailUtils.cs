using System.Net;
using System.Net.Mail;

namespace MailUtils
{
    public class MailUtils
    {
        // localhost
        public static async Task<string> SendMail(string from,
        string to,
        string subject,
        string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(from));
            message.Sender = new MailAddress(from, "Nam Phuong Nguyen");

            using var smtpClient = new SmtpClient("localhost");

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Gui mail thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return $"Gui mail that bai : {e.Message}";
            }
        }

        public static async Task<string> SendGmail(
            string from,
            string to,
            string subject,
            string body,
            string gmail,
            string password)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(from));
            message.Sender = new MailAddress(from, "Nam Phuong Nguyen");

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(gmail, password);

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Gui mail thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return $"Gui mail that bai : {e.Message}";
            }
        }
    }
}