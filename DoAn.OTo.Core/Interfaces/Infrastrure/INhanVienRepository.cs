using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface INhanVienRepository :IBaseRepository<NhanVien>
    {
        int Delete(string MaNV);
        int Update(NhanVien nhanVien, string MaNV);
        IEnumerable<NhanVien> GetByCH(Guid MaCH);
        Task<IEnumerable<NhanVien>> GetPage(int page, int pageSize);

    }
}
