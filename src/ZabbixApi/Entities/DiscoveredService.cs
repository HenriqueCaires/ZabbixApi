using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public class DiscoveredService
    {
        #region Properties
        /// <summary>
        /// ID of the discovered service.
        /// </summary>
        public string dserviceid { get; set; }

        /// <summary>
        /// ID of the discovery check used to detect the service.
        /// </summary>
        public string dcheckid { get; set; }

        /// <summary>
        /// ID of the discovered host running the service.
        /// </summary>
        public string dhostid { get; set; }

        /// <summary>
        /// DNS of the host running the service.
        /// </summary>
        public string dns { get; set; }

        /// <summary>
        /// IP address of the host running the service.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Key used by a Zabbix agent discovery check to locate the service.
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// Time when the discovered service last went down.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastdown { get; set; }

        /// <summary>
        /// Time when the discovered service last went up.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastup { get; set; }

        /// <summary>
        /// Service port number.
        /// </summary>
        public int port { get; set; }

        /// <summary>
        /// Status of the service. 
        /// 
        /// Possible values: 
        /// 0 - service up; 
        /// 1 - service down.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// Type of discovered service. The type of service matches the type of the discovery check used to detect the service. 
        /// 
        /// Refer to the discovery check "type" property for a list of supported types.
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// Value returned by the service when performing a Zabbix agent, SNMPv1, SNMPv2 or SNMPv3 discovery check.
        /// </summary>
        public string value { get; set; }
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
