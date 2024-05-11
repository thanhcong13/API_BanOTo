using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class CTHoaDon
    {
        [PrimaryKey]
        public Guid MaCTHD { get; set; }
        public Guid MaSP { get; set; }
        public Guid MaHD { get; set; }
        public DateTime Created_at { get; set; }
    }
}
