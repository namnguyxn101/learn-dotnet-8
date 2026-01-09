namespace lesson009_methods
{
    public class TinhToan
    {
        public static int Tong(int a, int b) => a + b;

        public static float Tong(float a, float b) => a + b;

        public static int BinhPhuong(ref int x) => x *= x;

        public static void BinhPhuong(int x, out int result) => result = x * x;
    }
}