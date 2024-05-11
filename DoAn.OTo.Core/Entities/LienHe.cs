using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class LienHe
    {
        [PrimaryKey]
        public Guid MaLH { get; set; }
        public string TenKH { get; set; }
        public string EmailKH { get; set; }
        public string SDTKH { get; set; }
        public string NoiDung { get; set; }

    }
}
