using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class CuaHang
    {
        [PrimaryKey]
        public Guid MaCH { get; set; }
        [NotEmpty]
        [ProppertyName("Tên của hàng")]
        public string TenCH { get; set; }
        [NotEmpty]
        [ProppertyName("Địa chỉ cửa hàng")]
        public string DiaChi { get; set; }

    }
}
