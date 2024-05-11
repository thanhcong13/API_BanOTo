using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class HinhAnh
    {
        [PrimaryKey]
        public Guid MaHA { get; set; }
        public string Url { get; set; }
        public Guid MaSP { get; set; }
    }
}
