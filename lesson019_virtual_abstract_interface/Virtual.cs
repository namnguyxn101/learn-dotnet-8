namespace Virtual
{
    // Virtual method: là phương thức đc định nghĩa trong lớp cơ sở và có thể đc ghi đè bởi lớp kế thừa.
    class Product
    {
        protected double Price { set; get; }

        // Từ khóa "virtual" cho phép lớp kế thừa có thể ghi đè phương thức bằng từ khóa "override"
        public virtual void ProductInfo()
        {
            Console.WriteLine($"Gia san pham: {Price}");
        }
    }

    class Samsung : Product
    {
        public Samsung() => Price = 800;

        // override: Cho biết phương thức này sẽ ghi đè vào 1 phương thức ở lớp cơ sở.
        // Việc này gọi là nạp chồng phương thức.
        public override void ProductInfo()
        {
            Console.WriteLine("Dien thoai Samsung");
            // Gọi đến phương thức từ lớp cơ sở
            base.ProductInfo();
        }
    }
}