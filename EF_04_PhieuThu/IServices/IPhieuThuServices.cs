using EF_04_PhieuThu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.IServices
{
    internal interface IPhieuThuServices
    {
        public LogType ThemNguyenLieuVaoLoaiNguyenLieu(int LoaiNguyenLieuId);
        public LogType ThemDanhSachChiTietPhieuThu(int PhieuThuId, int SoLuong);
        public LogType ThemPhieuThu();
        public LogType XoaPhieuThu(int PhieuThuId);
        public LogType InDanhSachPhieuThuTheoThoiGian(DateTime ThoiGian);
    }
}
