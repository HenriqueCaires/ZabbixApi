using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class GlobalMacro
    {
        /// <summary>
        /// (readonly) ID of the global macro.
        /// </summary>
        public string globalmacroid { get; set; }

        /// <summary>
        /// Macro string.
        /// </summary>
        public string macro { get; set; }

        /// <summary>
        /// Value of the macro.
        /// </summary>
        public string value { get; set; }
    }

    public partial class HostMacro
    {
        /// <summary>
        /// (readonly) ID of the host macro.
        /// </summary>
        public string hostmacroid { get; set; }

        /// <summary>
        /// ID of the host that the macro belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// Macro string.
        /// </summary>
        public string macro { get; set; }

        /// <summary>
        /// Value of the macro.
        /// </summary>
        public string value { get; set; }
    }
}
