# Entity Framework Core (.NET 8)

## Giới thiệu về Entity Framework Core
**EF Core** là framework (thư viện khung) để ánh xạ các đơn vị dữ liệu mô tả bằng lớp (đối tượng) vào cơ sở dữ liệu quan hệ, nó cho phép ánh xạ vào các bảng CSDL, tạo CSDL, truy vấn với LINQ, tạo và cập nhật vào database.

Để sử dụng `EF Core` hãy thêm những package cần thiết vào, chạy các lệnh sau:
```bash
dotnet add package Microsoft.Data.SqlClient --version 6.1.4
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.23
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.23
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.23
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging --version 10.0.2
dotnet add package Microsoft.Extensions.Logging.Console --version 10.0.2
```

Muốn cài thêm nuget để sử dụng MySQL, chạy lệnh:
```bash
dotnet add package MySql.EntityFrameworkCore --version 9.0.9
```