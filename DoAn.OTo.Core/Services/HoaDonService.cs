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
    public class HoaDonService :BaseService<HoaDon> , IHoaDonService
    {
        IHoaDonRepository _hoaDonRepository;
        public HoaDonService(IHoaDonRepository hoaDonRepository):base(hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
        }
    }
}
