# Sinh ra các entity từ database với công cụ dotnet ef trong C# 

### Sử dụng công cụ dòng lệnh EF Core, lệnh dotnet ef dbcontext scaffold để từ database sinh ra các entity

Ở các phần trước đã sử dụng EF theo hướng viết ra các Model, Entity từ đó sinh ra Database. Tuy nhiên nếu muốn đi theo chiều ngược lại, từ Database có sẵn nó sinh ra các Entity, các lớp biểu biểu diễn mảng thì ta có thể sử dụng đến công cụ dòng lệnh dotnet-ef

Nếu chưa có công cụ này thì cài đặt vào bằng lệnh
```bash
dotnet tool install --global dotnet-ef
```
Gõ lệnh sau để kiếm tra
```bash
dotnet ef
```
Hãy đảm bảo trong dự án muốn từ Database sinh ra các entity có thêm các package sau:
```bash
dotnet add package Microsoft.Data.SqlClient --version 6.1.4
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.23
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.23
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.23
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging --version 10.0.2
dotnet add package Microsoft.Extensions.Logging.Console --version 10.0.2
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.23
```

### Các lệnh migration
Để tạo migration mới, chạy lệnh:
```bash
dotnet ef migrations add [migration-name]
```
Để kiểm tra danh sách migration đang có, chạy lệnh:
```bash
dotnet ef migrations list
```
Để xóa migration cuối cùng, chạy lệnh:
```bash
dotnet ef migrations remove
```
Để cập nhật các migration lên db, chạy lệnh:
```bash
dotnet ef migrations update
```
Trường hợp muốn cập nhật một migration cụ thể, chạy lệnh:
```bash
dotnet ef database update [migration-name]
```
Để xóa db, chạy lệnh:
```bash
dotnet ef database drop -f
```
