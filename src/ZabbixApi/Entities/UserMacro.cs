using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix.Entities
{
    public partial class GlobalMacro : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the global macro.
        /// </summary>
        [JsonProperty("globalmacroid")]
        public override string Id { get; set; }

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

    public partial class HostMacro : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the host macro.
        /// </summary>
        [JsonProperty("hostmacroid")]
        public override string Id { get; set; }

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
