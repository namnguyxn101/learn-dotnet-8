# Send Gmail

# Dùng MailKit gửi Mail trong ASP.NET với Gmail
SmtpClient mặc dù vẫn được dùng nhưng .NET đánh dấu nó lỗi thời về khuyên dùng MailKit (https://github.com/jstedfast/MimeKit). Để tích hợp thư viện MailKit bạn thực hiện các lệnh:
```bash
dotnet add package MailKit
dotnet add package MimeKit
```