using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface ISanPhamRepository :IBaseRepository<SanPham>
    {
        IEnumerable<SanPham> GetByName(string name);
        IEnumerable<SanPham> GetByMaCH(Guid MaCH);
        IEnumerable<SanPham> GetByHang(Guid MaHang);
        Task<IEnumerable<SanPham>> GetPage(int page, int pageSize);
    }
}
