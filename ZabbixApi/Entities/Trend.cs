using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class Trend : EntityBase
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
        [JsonProperty("itemid")]
        public override string Id { get; set; }
        /// <summary>
        /// Number of values within this hour.
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// Hourly minimum value.
        /// </summary>
        public string value_min { get; set; }
        /// <summary>
        /// Hourly average value.
        /// </summary>
        public string value_avg { get; set; }
        /// <summary>
        /// Hourly maximum value.
        /// </summary>
        public string value_max { get; set; }

        #endregion
    }
}
