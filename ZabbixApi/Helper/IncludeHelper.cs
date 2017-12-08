using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Helper
{
    public class IncludeHelper
    {
        int _permission;

        public IncludeHelper(int permission)
        {
            _permission = permission;
        }

        public string WhatShouldInclude(int policy)
        {
            //Permission to All
            if (((1 & _permission) != 0))
                return "extend";

            //Permission to None
            if (((2 & _permission) != 0))
                return null;

            return ((policy & _permission) != 0) ? "extend" : null;
        }

        public string WhatShouldInclude(IConvertible policy)
        {
            return WhatShouldInclude((int) policy);
        }
    }
}
