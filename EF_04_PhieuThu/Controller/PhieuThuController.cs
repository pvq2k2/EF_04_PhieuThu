using EF_04_PhieuThu.Helper;
using EF_04_PhieuThu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Controller
{
    public class PhieuThuController
    {
        PhieuPhuServices services;

        public PhieuThuController()
        {
            services = new PhieuPhuServices();
        }

        public void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    int LoaiNguyenLieuId = InputHelper.InputInt("Nhap ID loai nguyen muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.PhieuThuLog(services.ThemNguyenLieuVaoLoaiNguyenLieu(LoaiNguyenLieuId));
                    break;
                case '2':
                    int PhieuThuId_Add = InputHelper.InputInt("Nhap ID phieu thu muon them: ", "Vui long nhap vao la mot so!");
                    int SoLuong = InputHelper.InputInt("Nhap so luong muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.PhieuThuLog(services.ThemDanhSachChiTietPhieuThu(PhieuThuId_Add, SoLuong));
                    break;
                case '3':
                    LogHelper.PhieuThuLog(services.ThemPhieuThu());
                    break;
                case '4':
                    int PhieuThuId_Remove = InputHelper.InputInt("Nhap ID phieu thu muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.PhieuThuLog(services.XoaPhieuThu(PhieuThuId_Remove));
                    break;
                case '5':
                    DateTime dateTime = InputHelper.InputDateTime("Nhap (nam/thang/ngay): ", "Vui long nhap theo kieu (yyyy/MM/dd)!");
                    LogHelper.PhieuThuLog(services.InDanhSachPhieuThuTheoThoiGian(dateTime));
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Khong co chuc nang nay, vui long nhap lai!");
                    break;
            }
            Console.WriteLine("\nNhan phim bat ky de tiep tuc!");
            Console.ReadKey();
        }
    }
}
