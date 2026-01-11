namespace Interface
{
    // Interface giống abstract, tức là khai báo ra cấu trúc 1 lớp ko dc dùng để khởi tạo đối tượng, nó chỉ được dùng để làm cơ sở cho lớp kế thừa.
    // Nó khác abstract ở chỗ các phương thức trong nó mặc định là abstract method
    interface IHinhHoc
    {
        double TinhChuVi();
        double TinhDienTich();
    }
    interface IAbc { }
    interface IXyz { }

    // Có thể thêm nhiều giao diện
    class HinhChuNhat : IHinhHoc, IAbc, IXyz
    {
        public double ChieuDai { set; get; }
        public double ChieuRong { set; get; }

        public HinhChuNhat(double _ChieuDai, double _ChieuRong)
        {
            ChieuDai = _ChieuDai;
            ChieuRong = _ChieuRong;
        }

        // Triển khai phương thức TinhChuVi của IHinhHoc, ko phải ghi đè
        public double TinhChuVi() => (ChieuDai + ChieuRong) * 2;
        // Triển khai phương thức TinhDienTich của IHinhHoc, ko phải ghi đè
        public double TinhDienTich() => ChieuDai * ChieuRong;
    }

    class HinhTron : IHinhHoc
    {
        public double r { set; get; }

        public HinhTron(double _r)
        {
            r = _r;
        }

        // Triển khai phương thức TinhChuVi của IHinhHoc, ko phải ghi đè
        public double TinhChuVi() => 2 * Math.PI * r;
        // Triển khai phương thức TinhDienTich của IHinhHoc, ko phải ghi đè
        public double TinhDienTich() => Math.PI * r * r;
    }
}