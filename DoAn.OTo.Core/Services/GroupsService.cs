using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class GroupsService :BaseService<Groups> , IGroupsService
    {
        IGroupsReporitory _groupsReporitory;
        public GroupsService(IGroupsReporitory groupsReporitory) :base(groupsReporitory)
        {
            _groupsReporitory = groupsReporitory;
        }

       
    }
}
