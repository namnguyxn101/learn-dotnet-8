using System.ComponentModel.DataAnnotations;
using System.Reflection;

// Mô tả được sử dụng ở đâu (Class, Method, Property, ...)
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
class MotaAttribute : Attribute
{
    public string? ThongTinChiTiet { get; set; }

    public MotaAttribute(string _ThongTinChiTiet)
    {
        ThongTinChiTiet = _ThongTinChiTiet;
    }
}

[Mota("Lớp chứa thông tin về User trên hệ thống")]
class User
{
    // ObsoleteAttribute - đánh dấu lớp, phương thức đã lỗi thời ko nên dùng

    [Mota("Tên người dùng")]
    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên phải dài từ 3-50 ký tự")]
    public string? Name { get; set; }

    [Mota("Tuổi")]
    [Range(18, 80, ErrorMessage = "Tuổi phải từ 18-80")]
    public int Age { get; set; }

    [Mota("Số điện thoại")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Mota("Địa chỉ email")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    public string? Email { get; set; }

    // [Obsolete("Phương thức này không nên sử dụng nữa (khuyên dùng ShowInfo())")]
    public void PrintInfo() => Console.WriteLine(Name);
}

class Program
{
    // Type - là lớp chứa các thông tin về kiểu dữ liệu nào đó (class, struct, ... int, bool, ...)
    // Lớp Type là thành phần cơ bản trong .NET được dùng trong kỹ thuật Reflection
    // Reflection: Lấy thông tin kiểu dữ liệu tại thời điểm thực thi
    // Attribute - cung cấp thông tin bổ sung cho lớp, phương thức, ...
    static void Main()
    {
        // Type t1 = typeof(int);
        // var t2 = typeof(string);
        // var t3 = typeof(Array);

        // int a = 1;
        // // Để lấy được type của biến nào đó --> dùng GetType()
        // var t = a.GetType();

        // // Để lấy tên type --> dùng FullName
        // Console.WriteLine(t.FullName);
        // ====================================

        // int[] a = [1, 3, 5];

        // Type t = a.GetType(); // ~ typeof(Array)

        // Console.WriteLine("---------------- Các thuộc tính");
        // // Để lấy danh sách các thuộc tính của type đó --> dùng GetProperties()
        // t.GetProperties().ToList().ForEach((PropertyInfo p) => Console.WriteLine(p.Name));

        // Console.WriteLine("---------------- Các trường dữ liệu");
        // // Để lấy danh sách các trường dữ liệu của type đó --> dùng GetFields()
        // t.GetFields().ToList().ForEach((FieldInfo p) => Console.WriteLine(p.Name));

        // Console.WriteLine("---------------- Các phương thức");
        // // Để lấy danh sách các phương thức của type đó --> dùng GetMethods()
        // t.GetMethods().ToList().ForEach((MethodInfo p) => Console.WriteLine(p.Name));

        // // Ngoài ra còn các phương thức lấy các thông tin khác như: GetConstructors, GetEnumNames, GetEvents, ...
        // ====================================

        User user = new User()
        {
            // Name = "Nguyen Phuong Nam",
            Name = null,
            // Age = 22,
            Age = 12,
            PhoneNumber = "0123456789",
            Email = "phuongnam@example.com",
        };

        // var properties = user.GetType().GetProperties();

        // foreach (PropertyInfo property in properties)
        // {
        //     foreach (var attr in property.GetCustomAttributes(false))
        //     {
        //         MotaAttribute? mota = attr as MotaAttribute;

        //         if (mota != null)
        //         {
        //             string name = property.Name;
        //             var value = property.GetValue(user);

        //             Console.WriteLine($"{name} - {mota.ThongTinChiTiet}: {value}");
        //         }
        //     }
        // }

        // // user.PrintInfo();
        // ====================================

        ValidationContext context = new ValidationContext(user);

        var result = new List<ValidationResult>();

        bool kq = Validator.TryValidateObject(user, context, result, true);

        if (kq == false)
        {
            result.ToList().ForEach((ValidationResult err) =>
            {
                // Check các p.tử trong mảng err.MemberNames
                // Console.WriteLine(string.Join(',', err.MemberNames));
                
                Console.WriteLine(err.MemberNames.First());
                Console.WriteLine(err.ErrorMessage);
            });
        }
    }
}