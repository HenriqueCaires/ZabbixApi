using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class GlobalMacro
    {
        #region Properties

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

        #endregion
    }

    public partial class HostMacro
    {
        #region Properties

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

        #endregion
    }
}
