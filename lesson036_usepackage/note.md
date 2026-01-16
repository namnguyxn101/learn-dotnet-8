# Cài đặt package từ Nuget
## Lệnh cài đặt
Sử dụng lệnh .NET CLI để cài package:
```bash
dotnet add package [package_name] --version xxx
```
Để loại bỏ package khỏi dự án, chạy lệnh:
```bash
dotnet remove package [package_name]
```
Nếu trong quá trình cài các thư viện về bị lỗi, chạy lệnh:
```bash
dotnet restore
```
Để tham chiếu dự án này đến dự án thư viện khác, chạy lệnh:
```bash
dotnet add [project_name].csproj reference [library_name].csproj
```
Chạy lệnh `pwd` **(print working directory)** để xem đường dẫn đến thư mục hiện tại.

## Chia sẻ thư viện lên Nuget.org
Vào trang https://www.nuget.org/ đăng ký một tài khoản và đăng nhập vào.

Truy cập địa chỉ https://www.nuget.org/account/apikeys để lấy API Key. Bấm vào Create điền các thông tin như key name điền tên do bạn đặt, `Glob Pattern` thì điến *, sau đó bấm vào Create.

Khi API Key được tạo, bấm vào copy để lấy, key có dạng như: `oy2aebwkfhj3jcg5k7aarfahset74gsejnljx42pwabcde`

Để chi sẻ thư viện, nó cần biên dịch và đóng gói thành file .nupkg, tại thư mục dự án bạn gõ lệnh:
```bash
dotnet pack
```
Nó sinh ra file tại đường dẫn: `/home/namnguyxn101/learn-tech/learn-dotnet-8/Utils/bin/Release/XTL.Utils.1.0.0.nupkg`

Nếu muốn mỗi lần lệnh dotnet build thì nó đóng gói nupkg luôn thì thêm vào mục `<PropertyGroup>`
```xml
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
```
Tiến hành chia sẻ lên nuget.org, ở thư mục chứa file nupkg gõ lệnh sau:
```bash
dotnet nuget push XTL.HtmlHelper.1.0.0.nupkg --api-key qz2jga8pl3dvn2akksyquwcs9ygggg4exypy3bhxy6w6x6 --source https://api.nuget.org/v3/index.json
```
Nhớ thay chính xác API Key.

Sau lệnh này, quá trình đẩy lên nuget.org diễn ra, sau đó nuget.org sẽ kiểm tra gói, nếu nó không chứa mã độc thì sẽ được public (có thể mất hàng giờ kiểm tra) và có thể tải về.

Sau khi đưa lên nuget.org, ai cũng có thể tích hợp vào code của họ bằng lệnh
```bash
dotnet add package XTL.Utils --version 1.0.0
```