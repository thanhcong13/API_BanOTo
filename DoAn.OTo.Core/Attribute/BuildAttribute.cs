using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.BuidAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ProppertyName:Attribute 
    { 
        public string Name = string.Empty;
        public ProppertyName(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }
}
