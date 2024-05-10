using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface IBaseRepository<OToEntity>
    {
        IEnumerable<OToEntity> GetAll();
        int Inssert(OToEntity entity);
        int Update(OToEntity entity , Guid entityID);
        int Delete(Guid entityID);
        // bool CheckDulicateCode(Guid entityID);


    }
}
