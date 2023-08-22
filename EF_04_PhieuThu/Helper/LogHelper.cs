using EF_04_PhieuThu.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Helper
{
    public enum LogType
    {
        Thoat,
        KhongTimThayLoaiNguyenLieu,
        KhongTimThayPhieuThu,
        DanhSachTrong,
        ThanhCong
    }
    public class LogHelper
    {
        public static void PhieuThuLog(LogType log)
        {
            switch (log)
            {
                case LogType.ThanhCong:
                    Console.WriteLine(PhieuThuRes.ThanhCong);
                    break;
                case LogType.KhongTimThayLoaiNguyenLieu:
                    Console.WriteLine(PhieuThuRes.KhongTimThayLoaiNguyenLieu);
                    break;
                case LogType.KhongTimThayPhieuThu:
                    Console.WriteLine(PhieuThuRes.KhongTimThayPhieuThu);
                    break;
                case LogType.DanhSachTrong:
                    Console.WriteLine(PhieuThuRes.DanhSachTrong);
                    break;
            }
        }
    }
}
