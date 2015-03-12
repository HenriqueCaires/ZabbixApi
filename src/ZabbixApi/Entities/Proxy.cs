using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public class Proxy
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the proxy.
        /// </summary>
        public string proxyid { get; set; }

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

        #region ENUMS

        public enum ProxyType
        {
            Active = 5,
            Passive = 6
        }

        #endregion
    }
}
