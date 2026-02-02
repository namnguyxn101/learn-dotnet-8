var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");

builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddTransient<SendMailService>();

var app = builder.Build();

/** 
 * Để gửi được mail --> cần máy chủ Mail Server (smtp - Simple Mail Transfer Protocol)
 * SmtpClient (.NET)
 * Server: Mail Transporter (CentOS - có sẵn, Qmail, SendMail)
*/

app.MapGet("/", () => "Hello World!");

app.MapGet("/testsendmail", async (context) =>
{
   var message = await MailUtils.MailUtils.SendMail("phuongnam8481@gmail.com", "phuongnam8481@gmail.com", "Test", "Xin chao");
   await context.Response.WriteAsync(message);
});

app.MapGet("/testsendgmail", async (context) =>
{
   var message = await MailUtils.MailUtils.SendGmail("phuongnam8481@gmail.com", "phuongnam8481@gmail.com", "Test", "Xin chao", "namdemoit11@gmail.com", "matkhau o day");
   await context.Response.WriteAsync(message);
});

app.MapGet("/testsendmailservice", async (context) =>
{
   var sendMailService = context.RequestServices.GetService<SendMailService>();
   string kq = "No data";

   if (sendMailService != null)
   {
      var mailContent = new MailContent();
      mailContent.To = "phuongnam8481@gmail.com";
      mailContent.Subject = "KIEM TRA THU EMAIL";
      mailContent.Body = "<h1>TEST</h1><i>Xin chao Phuong Nam</i>";

      kq = await sendMailService.SendMail(mailContent);
   }

   await context.Response.WriteAsync(kq);
});

app.Run();
