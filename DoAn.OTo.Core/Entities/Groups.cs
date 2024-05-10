using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class Groups
    {
        [PrimaryKey]   
        
        public string GID { get; set; }
        [NotEmpty]
        [ProppertyName("Tên group")]
        public string Name { get; set; }

    }
}
