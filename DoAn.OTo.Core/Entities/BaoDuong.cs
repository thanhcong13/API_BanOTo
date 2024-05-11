using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class BaoDuong
    {
        [PrimaryKey]
        public Guid MaBD { get ; set; }
        public string TenKH { get; set; }
        public string EmailKH { get; set; }
        public string SDTKH { get; set; }
        public string TenSP { get; set; }
        public DateTime NgayBD { get; set; }
        public Guid MaCH { get; set; }

    }
}
