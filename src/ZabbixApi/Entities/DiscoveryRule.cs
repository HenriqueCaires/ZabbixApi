using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public partial class DiscoveryRule
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the discovery rule.
        /// </summary>
        public string druleid { get; set; }

        /// <summary>
        /// One or several IP ranges to check separated by commas. 
        /// 
        /// Refer to the network discovery configuration section for more information on supported formats of IP ranges.
        /// </summary>
        public string iprange { get; set; }

        /// <summary>
        /// Name of the discovery rule.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Execution interval of the discovery rule in seconds. 
        /// 
        /// Default: 3600.
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// (readonly) Time when the discovery rule will be executed next.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime nextcheck { get; set; }

        /// <summary>
        /// ID of the proxy used for discovery.
        /// </summary>
        public string proxy_hostid { get; set; }

        /// <summary>
        /// Whether the discovery rule is enabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }
        #endregion

        #region ENUMS
        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }
        #endregion
    }
}
