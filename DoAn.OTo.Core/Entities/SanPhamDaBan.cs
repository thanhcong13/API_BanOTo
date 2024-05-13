using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class SanPhamDaBan
    {
        [PrimaryKey]
        public Guid MaSPDB { get; set; }
        public Guid MaSP { get; set; }
    }
}
