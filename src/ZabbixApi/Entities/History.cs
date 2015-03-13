using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public partial class History
    {
        #region Properties
        /// <summary>
        /// Time when that value was received.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// ID of the related item.
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// Nanoseconds when the value was received.
        /// </summary>
        public int ns { get; set; }

        /// <summary>
        /// Received value.
        /// </summary>
        public string value { get; set; }

        #endregion
    }
}
