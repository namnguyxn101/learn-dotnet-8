namespace Abstract
{
    // Abstract: là lớp trừu tượng, đã là lớp abstract thì ko được dùng để khởi tạo ra các đối tượng, chỉ được dùng làm cơ sở cho các lớp kế thừa.
    abstract class Product
    {
        protected double Price { set; get; }

        // Từ khóa "abstract" chỉ cho phép tạo ra hàm mà ko có phần thân
        // Phần thân phải đc nạp chồng ở lớp kế thừa bằng "override"
        // Khai báo lớp là abstract mới có thể dùng abstract method
        public abstract void ProductInfo();
        public void Test() => ProductInfo();
    }

    class Samsung : Product
    {
        public Samsung() => Price = 800;

        // Nạp chồng phương thức abstract đc khai báo mà chưa định nghĩa trong lớp cơ sở
        public override void ProductInfo()
        {
            Console.WriteLine("Dien thoai Samsung");
            Console.WriteLine($"Gia san pham: {Price}");
        }
    }
}