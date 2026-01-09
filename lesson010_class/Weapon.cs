using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson010_class
{
    /*
        <Access Modifiers> class Class_name
        {
            // Khai báo các thành viên dữ liệu (thuộc tính, biến trường)
            // Khai báo các thành viên hàm (phương thức)
        }
        public: Lớp có phạm vi truy cập bất kì đâu
        internal: Chỉ được truy cập trong cùng 1 chương trình
        --> Ko chỉ ra access modifiers thì mặc định class sẽ là internal
    */
    public class Weapon
    {
        // DỮ LIỆU
        // Ko chỉ ra access modifiers thì mặc định sẽ là private
        string Name = "Vu khi khong ten";
        int Damage = 0;

        // THUỘC TÍNH
        public string Manufacture { set; get; } = "";
        public string _Name
        {
            // Được thi hành khi thực hiện gán
            set
            {
                Name = value;
            }
            // Được thi hành khi truy cập. Phải return về giá trị cùng kiểu với thuộc tính
            get
            {
                return Name;
            }
        }
        public int _Damage
        {
            // Được thi hành khi thực hiện gán
            set
            {
                Damage = value;
            }
            // Được thi hành khi truy cập. Phải return về giá trị cùng kiểu với thuộc tính
            get
            {
                return Damage;
            }
        }

        // PHƯƠNG THỨC KHỞI TẠO
        public Weapon()
        {
            Console.WriteLine("Tao vu khi");
            // Name = "Vu khi khong ten";
            // DoSatThuong = 0;
        }

        public Weapon(string Name, int Damage)
        {
            this.Name = Name;
            this.Damage = Damage;
        }

        // PHƯƠNG THỨC
        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetDamage(int Damage)
        {
            this.Damage = Damage;
        }

        public void Attack()
        {
            Console.Write("Tan cong: ");
            for (int i = 0; i < Damage; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}