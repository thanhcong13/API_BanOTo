using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface ITaiKhoanRepository : IBaseRepository<TaiKhoan>
    {
        int Delete(string TenTaiKhoan);
        int Update (TaiKhoan taikhoan , string TenTaiKhoan);
        Task<IEnumerable<TaiKhoan>> GetPage(int page, int pageSize);

    }
}
