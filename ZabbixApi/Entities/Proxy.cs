using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class Proxy : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the proxy.
        /// </summary>
        [JsonProperty("proxyid")]
        public override string Id { get; set; }

        /// <summary>
        /// (readonly) ID of the proxy.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Type of proxy. 
        /// 
        /// Possible values:
        /// 5 - active proxy;
        /// 6 - passive proxy.
        /// </summary>
        public ProxyType status { get; set; }

        /// <summary>
        /// (readonly) Time when the proxy last connected to the server.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastaccess { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Hosts monitored by the proxy
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// The proxy interface used by a passive proxy
        /// </summary>
        [JsonProperty("interface")]
        [JsonConverter(typeof(SingleObjectConverter<ProxyInterface>))]
        public ProxyInterface @interface { get; set; }

        #endregion

        #region ENUMS

        public enum ProxyType
        {
            Active = 5,
            Passive = 6
        }

        #endregion
    }

    public partial class ProxyInterface : EntityBase
    {
        #region Properties
        
        /// <summary>
        /// (readonly) ID of the interface.
        /// </summary>
        [JsonProperty("interfaceid")]
        public override string Id { get; set; }

        /// <summary>
        /// DNS name to connect to. 
        /// 
        /// Can be empty if connections are made via IP address.
        /// </summary>
        public string dns { get; set; }

        /// <summary>
        /// IP address to connect to. 
        /// 
        /// Can be empty if connections are made via DNS names.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Port number to connect to.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// Whether the connection should be made via IP address. 
        /// 
        /// Possible values are: 
        /// 0 - connect using DNS name; 
        /// 1 - connect using IP address.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool useip { get; set; }

        /// <summary>
        /// (readonly) ID of the proxy the interface belongs to.
        /// </summary>
        public string hostid { get; set; }
        
        #endregion
    }
}
