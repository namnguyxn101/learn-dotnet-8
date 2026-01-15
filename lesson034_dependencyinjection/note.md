# Dependency Injection (DI)

## Dependency Injection là gì?
> Là một trong những phương pháp áp dụng nguyên tắc IoC

**Dependency Injection** triển khai cụ thể nguyên tắc IoC, DI là kỹ thuật mà ta phải thiết kế ra một cơ chế nào đó để khi ClassA cần 1 **Dependency** thì khi thực thi --> cơ chế đó tự động bơm **Dependency** đó vào ClassA. **Dependency** đó cụ thể là gì --> có thể được quyết định bởi Interface được khai báo trong ClassA

## Cơ chế của Dependency Injection
Để thiết kế ra được cơ chế đó thì khá phức tạp --> sử dụng các thư viện có hỗ trợ DI như: 
- [`Microsoft.Extensions.DependencyInjection`](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/)
- [`Windsor`](https://github.com/castleproject/Windsor)
- [`Unity`](https://github.com/unitycontainer/unity)
- [`Ninject`](https://github.com/ninject/ninject)
- ...

> [!NOTE]
> **Lưu ý:** Để áp dụng được DI thì phải đưa các Dependency khởi tạo bên ngoài và đưa vào bên trong Class.

## Các phương pháp Inject
1. Inject thông qua **phương thức khởi tạo**: Cung cấp các Dependency cho đối tượng thông qua hàm khởi tạo **(tập trung vào cách này vì thư viện .NET hỗ trợ sẵn)**

2. Inject thông qua **setter**: Tức là các dependency như là thuộc tính của lớp, sau đó inject bằng gán thuộc tính cho Dependency `object.dependency = obj;`

3. Inject thông qua **Interface**: Xây dựng Interface có chứa các phương thức Setter để thiết lập dependency, interface này sử dụng bởi các lớp triển khai, lớp triển khai phải định các setter quy định trong interface.

## Chức năng của các thư viện hỗ trợ Dependency Injection
Có hỗ trợ một đối tượng **DI Container** --> đối tượng này cho phép đăng ký các dịch vụ **(Class)** vào trong nó. Sau đó, nó hỗ trợ lấy ra các dịch vụ **(GetService)**.

Khi lấy ra dịch vụ --> nó sẽ tạo ra đối tượng **(instance)** của dịch vụ đó và nếu đối tượng đó cần các **Dependency** (chưa có) thì nó sẽ tự khởi tạo các **Dependency** đó rồi tự động Inject vào dịch vụ.

## Cài đặt thư viện Microsoft.Extensions.DependencyInjection
Mở terminal chạy lệnh này để cài thư viện DI cho .NET 8
```bash
dotnet add package Microsoft.Extensions.DependencyInjection --version 10.0.2
```

## Thư viện DI Microsoft.Extensions.DependencyInjection
Trong thư viện này **DI Container** là lớp **ServiceCollection**.

Trước tiên, phải có đối tượng **ServiceCollection** để đăng ký các dịch vụ **(Class)** vào bên trong. Từ **ServiceCollection** ta có được đối tượng có kiểu **ServiceProvider** --> đối tượng này cho phép lấy ra các dịch vụ đã được đăng ký ở trong **ServiceCollection** thông qua `GetService`.

Để có được **provider** ta phải gọi `services.BuildServiceProvider()`.

---

### ServiceLifetime - Vòng đời của dịch vụ
Khi đăng ký dịch vụ vào **ServiceCollection** thì các dịch vụ đó tồn tại bao lâu phụ thuộc vào các kiểu sau:
- **Scoped**: Một bản thực thi (instance) của dịch vụ (Class) được tạo ra cho mỗi phạm vi, tức là tồn tại cùng với sự tồn tại của một đối tượng kiểu ServiceScope (đối tượng này tạo bằng cách gọi ServiceProvider.CreateScope, đối tượng này hủy thì dịch vụ cũng bị hủy).
- **Singleton**: Duy nhất một phiên bản thực thi (Instance of Class) (dịch vụ) được tạo ra cho hết vòng đợi của ServiceProvider.
- **Transient**: Một phiên bản của dịch vụ được tạo mỗi khi được yêu cầu.