using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Models
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        public string TenNguyenLieu { get; set; }
        public int GiaBan { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongKho { get; set; }

        public int LoaiNguyenLieuId { get; set; }
        public LoaiNguyenLieu LoaiNguyenLieu { get; set; }

        public void InThongTin() {
            Console.WriteLine($"-----Nguyen Lieu-----\n" +
                $"Ten nguyen lieu: {TenNguyenLieu}\n" +
                $"Gia ban: {GiaBan}\n" +
                $"Don vi tinh: {DonViTinh}\n" +
                $"So luong kho: {SoLuongKho}");
        }
    }
}
