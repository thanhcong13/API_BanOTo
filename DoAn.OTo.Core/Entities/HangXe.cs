using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class HangXe
    {
        [PrimaryKey]
        public Guid MaHang { get; set; }
        public string TenHang { get; set; }

    }
}
