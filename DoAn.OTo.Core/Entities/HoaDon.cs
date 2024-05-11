using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class HoaDon
    {
        [PrimaryKey]
        public Guid MaHD { get; set; }
        public Guid MaNV { get; set;}
        public double TriGia { get; set;}

        public DateTime Created_at { get; set; }    
    }
}
