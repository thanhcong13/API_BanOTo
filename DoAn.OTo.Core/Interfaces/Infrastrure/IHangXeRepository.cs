using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface IHangXeRepository :IBaseRepository<HangXe>
    {
        Task<IEnumerable<HangXe>> GetPage(int page, int pageSize);

    }
}
