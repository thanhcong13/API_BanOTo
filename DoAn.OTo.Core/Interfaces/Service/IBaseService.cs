using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Service
{
    public interface IBaseService<OToEmpty>
    {
        int InsertService(OToEmpty entity);
        int UpdateService(OToEmpty entity , Guid entityID);
        int DeleteService(Guid entityID);
    }
}
