using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class CuaHangService : BaseService<CuaHang>, ICuaHangService
    {
        ICuaHangRepository _cuaHangRepository;
        public CuaHangService(ICuaHangRepository cuaHangRepository):base(cuaHangRepository)
        {
            _cuaHangRepository = cuaHangRepository;
        }

       
    }
}
