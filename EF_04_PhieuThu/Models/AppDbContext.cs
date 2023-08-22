using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChiTietPhieuThu> ChiTietPhieuThu { get; set; }
        public DbSet<LoaiNguyenLieu> LoaiNguyenLieu { get; set; }
        public DbSet<NguyenLieu> NguyenLieu { get; set; }
        public DbSet<PhieuThu> PhieuThu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-O1GKQUN; Database = EF_04_PhieuThu; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
