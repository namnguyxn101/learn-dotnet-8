# Session

Cài 2 package:
```bash
dotnet add package Microsoft.AspNetCore.Session --version 2.3.9
dotnet add package Microsoft.Extensions.Caching.Memory --version 10.0.2
```

Để lưu cache trong sqlserver, cài package dotnet-sql-cache
```bash
dotnet new tool-manifest
dotnet tool install --local dotnet-sql-cache --version 8.0.23
```
Để tạo bảng Session trong Sql server, chạy lệnh:
```bash
dotnet sql-cache create "Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=Password123;TrustServerCertificate=true" dbo Session
```
Cài thêm package Microsoft.Extensions.Caching.SqlServer
```bash
dotnet add package Microsoft.Extensions.Caching.SqlServer --version 8.0.23
```