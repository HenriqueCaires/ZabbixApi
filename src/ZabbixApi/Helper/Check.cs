using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix.Helper
{
    public class Check
    {
        public static void NotNull(object value, string name = null)
        {
            if (value == null)
                throw new NullReferenceException(string.Format("The field {0} is null", name));
        }

        public static void NotEmpty(string value, string name = null)
        {
            if (string.IsNullOrEmpty(value))
                throw new NullReferenceException(string.Format("The field {0} is null or empty", name));
        }
    }
}
