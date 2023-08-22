using EF_04_PhieuThu.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.View
{
    public class PhieuThuView
    {
        PhieuThuController controller;

        public PhieuThuView()
        {
            controller = new PhieuThuController();
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1. Them nguyen lieu vao vao loai nguyen lieu");
                Console.WriteLine("2. Them danh sach chi tiet phieu thu");
                Console.WriteLine("3. Them phieu thu");
                Console.WriteLine("4. Xoa phieu thu");
                Console.WriteLine("5. In thong tin phieu thu theo thoi gian");
                Console.WriteLine("6. Thoat");
                Console.Write("Chon chuc nang: ");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                controller.ThucThi(c);
            }
        }
    }
}
