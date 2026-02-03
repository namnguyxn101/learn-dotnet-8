/**
 * Các chỉ thị:
 * @page: Đánh dấu đây là một Razor Page
 * @page "url": Chỉ định URL tùy chỉnh cho Razor Page
 * @page "url/{parameter}": Chỉ định URL với tham số động
 * @page "url/{parameter:int}": Tham số động kiểu int trong URL
 * @page "url/{parameter:alpha}": Tham số động chỉ chứa chữ cái
 * @page "url/{parameter?}": Tham số động tùy chọn trong URL
 * @page "url/{parameter:regex(\d{4})}": Tham số động với regex
 * 
 * @model: Chỉ định lớp model liên kết với Razor Page (nếu có)
 * @using: Nhập namespace để sử dụng trong Razor Page
 * @inject: Tiêm dịch vụ vào Razor Page
 * @functions: Định nghĩa các hàm hoặc thuộc tính trong Razor Page
 * @section: Định nghĩa một phần nội dung có thể được sử dụng trong layout
 * @layout: Chỉ định layout cho Razor Page
 * 
 * @variable, @(expression), @method: Chèn mã C# vào trong HTML
 * @if, @foreach, @for, @while: Cấu trúc điều khiển trong Razor Page
 * 
 * @{
 *   // Mã C# ở đây
 *   <!-- HTML ở đây -->
 * }
 * Tag Helper -> Phát sinh HTML
 * @addTagHelper
*/

var builder = WebApplication.CreateBuilder(args);

// Tích hợp engine Razor Pages
builder.Services.AddRazorPages().AddRazorPagesOptions((option) =>
{
    option.RootDirectory = "/Pages"; // Thư mục chứa các Razor Pages

    // Cấu hình định tuyến tùy chỉnh cho Razor Pages (Thường không cần thiết)
    // option.Conventions.AddPageRoute("/FirstPage", "/trang-dau-tien.html");
    // option.Conventions.AddPageRoute("/SecondPage", "/trang-thu-hai.html");
});

builder.Services.Configure<RouteOptions>((routeOptions) =>
{
    routeOptions.LowercaseUrls = true;
});

var app = builder.Build();

app.MapRazorPages();
/**
 * FirstPage.cshtml -> URL: /FirstPage
*/

app.MapGet("/", () => "Hello World!");

app.Run();
