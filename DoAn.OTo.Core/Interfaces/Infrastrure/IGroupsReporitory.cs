using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface IGroupsReporitory :IBaseRepository<Groups>
    {
        int Delete(string GID);
        int Update(Groups group , string GID);
        Task<IEnumerable<Groups>> GetPage(int page, int pageSize);

    }
}
