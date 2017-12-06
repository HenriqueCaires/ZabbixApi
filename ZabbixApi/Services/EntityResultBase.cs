using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Services
{
    public abstract class EntityResultBase
    {
        public virtual string[] ids { get; set; }
    }
}
