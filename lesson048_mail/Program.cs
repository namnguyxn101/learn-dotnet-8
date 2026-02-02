var builder = WebApplication.CreateBuilder(args);
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
   var message = await MailUtils.MailUtils.SendGmail("phuongnam8481@gmail.com", "phuongnam8481@gmail.com", "Test", "Xin chao", "namdemoit11@gmail.com", "uhzk uayo aimx tzjj"); 
   await context.Response.WriteAsync(message);
});

app.Run();
