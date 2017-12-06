using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class DiscoveryRule : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the discovery rule.
        /// </summary>
        [JsonProperty("druleid")]
        public override string Id { get; set; }

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

        #region Associations

        /// <summary>
        /// Discovery Checks
        /// </summary>
        public IList<DiscoveryCheck> dchecks { get; set; }

        /// <summary>
        /// Discovered Rules
        /// </summary>
        public IList<DiscoveredHost> dhosts { get; set; }

        #endregion

        #region ENUMS
        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }
        #endregion

        #region Constructors

        public DiscoveryRule()
        {
            delay = 3600;
            status = Status.Enabled;
        }

        #endregion
    }
}
