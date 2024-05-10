using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class SanPhamService : BaseService<SanPham>,ISanPhamService
    {
        ISanPhamRepository _sanPhamRepository;
        public SanPhamService(ISanPhamRepository sanPhamRepository) : base(sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

       

    }
}
