using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public partial class HostInterface
    {
        /// <summary>
        /// (readonly) ID of the interface.
        /// </summary>
        public string interfaceid { get; set; }

        /// <summary>
        /// DNS name used by the interface. 
        /// 
        /// Can be empty if the connection is made via IP.
        /// </summary>
        public string dns { get; set; }

        /// <summary>
        /// ID of the host the interface belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// IP address used by the interface. 
        /// 
        /// Can be empty if the connection is made via DNS.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Whether the interface is used as default on the host. Only one interface of some type can be set as default on a host. 
        /// 
        /// Possible values are: 
        /// 0 - not default; 
        /// 1 - default.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool main { get; set; }

        /// <summary>
        /// Port number used by the interface. Can contain user macros.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// Interface type. 
        /// 
        /// Possible values are: 
        /// 1 - agent; 
        /// 2 - SNMP; 
        /// 3 - IPMI; 
        /// 4 - JMX. 
        /// </summary>
        public InterfaceType type { get; set; }

        /// <summary>
        /// Whether the connection should be made via IP. 
        /// 
        /// Possible values are: 
        /// 0 - connect using host DNS name; 
        /// 1 - connect using host IP address.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool useip { get; set; }

        public enum InterfaceType
        {
            Agent = 1,
            SNMP = 2,
            IPMI = 3,
            JMX = 4
        }

    }
}
