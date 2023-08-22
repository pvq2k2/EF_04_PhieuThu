using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Models
{
    public class LoaiNguyenLieu
    {
        public int LoaiNguyenLieuId { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }

        public List<NguyenLieu> ListNguyenLieu { get; set; }
    }
}
