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
    public class CTLienHeService : BaseService<CTLienHe> , ICTLienHeService
    {
        ICTLienHeRepository _ctLienHeRepository;
        public CTLienHeService(ICTLienHeRepository ctLienHeRepository):base(ctLienHeRepository)
        {
            _ctLienHeRepository = ctLienHeRepository;
        }
    }
}
