using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Models
{
    public class PhieuThu
    {
        public int PhieuThuId { get; set; }
        public DateTime NgayLap { get; set; }
        public string NhanVienLap { get; set; }
        public string GhiChu { get; set; }
        public int ThanhTien { get; set; }

        public List<ChiTietPhieuThu> ListChiTietPhieuThu { get; set; }

        public void InThongTin() {
            Console.WriteLine("-----Phieu phu-----");
            Console.WriteLine($"Ngay lap: {NgayLap.ToShortDateString()}\n" +
                $"Nhan vien lap: {NhanVienLap}\n" +
                $"Ghi chu: {GhiChu}\n" +
                $"Thanh tien: {ThanhTien}\n");
        }
    }
}
