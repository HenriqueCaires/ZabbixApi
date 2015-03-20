using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace Zabbix.Entities
{
    public partial class DiscoveredHost : EntityBase
    {
        #region Properties
        /// <summary>
        /// ID of the discovered host.
        /// </summary>
        [JsonProperty("dhostid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the discovery rule that detected the host.
        /// </summary>
        public string druleid { get; set; }

        /// <summary>
        /// Time when the discovered host last went down.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastdown { get; set; }

        /// <summary>
        /// Time when the discovered host last went up.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastup { get; set; }

        /// <summary>
        /// Whether the discovered host is up or down. A host is up if it has at least one active discovered service. 
        /// 
        /// Possible values: 
        /// 0 - host up; 
        /// 1 - host down.
        /// </summary>
        public Status status { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Discovery rules
        /// </summary>
        public IList<DiscoveryRule> drules { get; set; }

        /// <summary>
        /// Discovered Services
        /// </summary>
        public IList<DiscoveredService> dservices { get; set; }

        #endregion

        #region ENUMS
        public enum Status
        {
            Up = 0,
            Down = 1
        }
        #endregion
    }
}
