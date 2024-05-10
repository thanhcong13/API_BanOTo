using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class SanPham
    {
        [PrimaryKey]
        public Guid MaSP { get; set; }

        [NotEmpty]
        [ProppertyName("Tên sản phẩm")] 
        
        public string TenSP { get; set; }
        [NotEmpty]
        [ProppertyName("Mã hàng")]
        public Guid MaHang { get; set; }
        [NotEmpty]
        [ProppertyName("Mã cửa hàng")]
        public Guid MaCH { get; set; }
        public string? MoTa { get; set; }
        public string? MauSac { get; set; }
        public DateTime? NamSX { get; set; }
        public DateTime? NamDangKy { get; set; }
        public float SoDam { get; set; }
        public string? DongCo { get; set; }
        public int? SoGhe { get; set; }
        public float? DungTich { get; set;}
        public string? LoaiHopSo { get; set; }

        
    }
}
