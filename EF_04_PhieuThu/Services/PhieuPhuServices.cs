using EF_04_PhieuThu.Helper;
using EF_04_PhieuThu.IServices;
using EF_04_PhieuThu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Services
{
    public class PhieuPhuServices : IPhieuThuServices
    {
        private readonly AppDbContext dbContext;

        public PhieuPhuServices()
        {
            dbContext = new AppDbContext();
        }

        public LogType InDanhSachPhieuThuTheoThoiGian(DateTime ThoiGian)
        {
            var ListPhieuThu = dbContext.PhieuThu
                .Include(x => x.ListChiTietPhieuThu)
                    .ThenInclude(x => x.NguyenLieu)
                .Where(x => x.NgayLap == ThoiGian)
                .ToList();

            if (ListPhieuThu.Count == 0)
                return LogType.DanhSachTrong;

            foreach (var phieuThu in ListPhieuThu)
            {
                phieuThu.InThongTin();

                if (phieuThu.ListChiTietPhieuThu.Count == 0)
                {
                    Console.WriteLine("Khong co chi tiet phieu thu nao!\n");
                }
                else
                {
                    foreach (var chiTietPhieuThu in phieuThu.ListChiTietPhieuThu)
                    {
                        Console.WriteLine("-----Chi tiet phieu thu-----");
                        Console.WriteLine($"Chi tiet phieu thu ID: {chiTietPhieuThu.PhieuThuId}, so luong ban {chiTietPhieuThu.SoLuongBan}");
                        var ListNguyenLieu = dbContext.NguyenLieu.Where(x => x.NguyenLieuId == chiTietPhieuThu.NguyenLieuId).ToList();
                        if (ListNguyenLieu.Count == 0)
                        {
                            Console.WriteLine("Khong co nguyen lieu nao!\n");
                        }
                        else
                        {
                            foreach (var nguyenLieu in ListNguyenLieu)
                            {
                                nguyenLieu.InThongTin();
                            }
                        }
                    }
                }
            }

            return LogType.ThanhCong;
        }


        public LogType ThemDanhSachChiTietPhieuThu(int PhieuThuId, int SoLuong)
        {
            var FindPhieuThu = dbContext.PhieuThu.FirstOrDefault(x => x.PhieuThuId == PhieuThuId);
            if (FindPhieuThu == null) return LogType.KhongTimThayPhieuThu;
            NhapDanhSachChiTietPhieuThu(FindPhieuThu, SoLuong);
            return LogType.ThanhCong;
        }

        private void NhapDanhSachChiTietPhieuThu(PhieuThu phieuThu, int SoLuong)
        {
            var ListChiTietPhieuThu = new List<ChiTietPhieuThu>();
            for (int i = 0; i < SoLuong; i++)
            {
                ChiTietPhieuThu chiTietPhieuThu = new ChiTietPhieuThu();
                chiTietPhieuThu.PhieuThuId = phieuThu.PhieuThuId;
                NguyenLieu? FindNguyenLieu;
                bool isExist = false;
                do
                {
                    chiTietPhieuThu.NguyenLieuId = InputHelper.InputInt("Nhap nguyen lieu id: ", "Vui long nhap vao so!");
                    isExist = dbContext.NguyenLieu.Any(x => x.NguyenLieuId == chiTietPhieuThu.NguyenLieuId);
                    FindNguyenLieu = isExist ? dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuId == chiTietPhieuThu.NguyenLieuId) : null;
                    chiTietPhieuThu.SoLuongBan = isExist ? InputHelper.InputInt("Nhap so luong ban: ", "Vui long nhap vao so!") : 0;
                    if (!isExist)
                    {
                        Console.WriteLine("Nguyen lieu khong ton tai");
                    }
                    else if (chiTietPhieuThu.SoLuongBan > FindNguyenLieu.SoLuongKho)
                    {
                        Console.WriteLine("So luong khong du");
                    }
                    else
                    {
                        isExist = true;
                        FindNguyenLieu.SoLuongKho -= chiTietPhieuThu.SoLuongBan;
                        phieuThu.ThanhTien += FindNguyenLieu.GiaBan * chiTietPhieuThu.SoLuongBan;

                        dbContext.NguyenLieu.Update(FindNguyenLieu);
                        dbContext.SaveChanges();

                        dbContext.PhieuThu.Update(phieuThu);
                        dbContext.SaveChanges();

                        ListChiTietPhieuThu.Add(chiTietPhieuThu);
                    }
                } while (!isExist);
                Console.WriteLine();
            }

            dbContext.ChiTietPhieuThu.AddRange(ListChiTietPhieuThu);
            dbContext.SaveChanges();
        }

        public LogType ThemNguyenLieuVaoLoaiNguyenLieu(int LoaiNguyenLieuId)
        {
            var FindLoaiNguyenLieu = dbContext.LoaiNguyenLieu.Any(x => x.LoaiNguyenLieuId == LoaiNguyenLieuId);
            if (!FindLoaiNguyenLieu) return LogType.KhongTimThayLoaiNguyenLieu;
            NguyenLieu nguyenLieu = new NguyenLieu();
            nguyenLieu.LoaiNguyenLieuId = LoaiNguyenLieuId;
            nguyenLieu.TenNguyenLieu = InputHelper.InputString("Nhap ten nguyen lieu: ", "Ten nguyen lieu khong duoc qua 20 ki tu!", maxValue: 20);
            nguyenLieu.GiaBan = InputHelper.InputInt("Nhap gia tien: ", "Vui long nhap la so!");
            nguyenLieu.DonViTinh = InputHelper.InputString("Nhap don vi tinh: ", "Don vi tinh khong duoc qua 10 ky tu", maxValue: 10);
            nguyenLieu.SoLuongKho = InputHelper.InputInt("Nhap so luong kho: ", "Vui long nhap la so!");

            dbContext.NguyenLieu.Add(nguyenLieu);
            dbContext.SaveChanges();

            return LogType.ThanhCong;
        }

        public LogType ThemPhieuThu()
        {
            PhieuThu phieuThu = new PhieuThu();
            phieuThu.NgayLap = DateTime.Now;
            phieuThu.NhanVienLap = InputHelper.InputString("Nhap ten nhan vien: ");
            phieuThu.GhiChu = InputHelper.InputString("Nhap ghi chu: ");

            dbContext.PhieuThu.Add(phieuThu);
            dbContext.SaveChanges();

            int SoLuong = InputHelper.InputInt("Nhap so luong phieu thu: ", "Vui long nhap la so!");
            NhapDanhSachChiTietPhieuThu(phieuThu, SoLuong);
            return LogType.ThanhCong;
        }

        public LogType XoaPhieuThu(int PhieuThuId)
        {
            var FindPhieuThu = dbContext.PhieuThu.FirstOrDefault(x => x.PhieuThuId == PhieuThuId);
            if (FindPhieuThu == null) return LogType.KhongTimThayPhieuThu;
            dbContext.PhieuThu.Remove(FindPhieuThu);
            dbContext.SaveChanges();
            Console.WriteLine($"Da xoa phieu thu co id la {FindPhieuThu.PhieuThuId}");

            return LogType.ThanhCong;
        }
    }
}
