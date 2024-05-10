using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class LaiThuService :BaseService<LaiThu>, ILaiThuService
    {
        ILaiThuRepository _laiThuRepository;
        public LaiThuService(ILaiThuRepository laiThuRepository):base(laiThuRepository)
        {
            _laiThuRepository = laiThuRepository;
        }
    }
}
