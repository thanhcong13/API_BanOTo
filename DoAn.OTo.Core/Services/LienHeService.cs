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
    public class LienHeService :BaseService<LienHe>, ILienHeService
    {
        ILienHeRepository _lienHeRepository;
        public LienHeService(ILienHeRepository lienHeRepository):base(lienHeRepository) 
        {
            _lienHeRepository = lienHeRepository;
        }
    }
}
