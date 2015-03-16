using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix.Helper
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
            return ((policy & _permission) != 0) || ((1 & _permission) != 0) ? "extend" : null;
        }
    }
}
