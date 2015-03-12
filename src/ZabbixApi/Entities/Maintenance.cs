using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public class Maintenance
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the maintenance.
        /// </summary>
        public string maintenanceid { get; set; }

        /// <summary>
        /// Name of the maintenance.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Time when the maintenance becomes active. 
        /// 
        /// Default: current time.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime active_since { get; set; }

        /// <summary>
        /// Time when the maintenance stops being active. 
        /// 
        /// Default: the next day.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime active_till { get; set; }

        /// <summary>
        /// Description of the maintenance.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Type of maintenance. 
        /// 
        /// Possible values: 
        /// 0 - (default) with data collection; 
        /// 1 - without data collection.
        /// </summary>
        public MaintenanceType maintenance_type { get; set; }

        #endregion

        #region ENUMS

        public enum MaintenanceType
        {
            WithDataCollection = 0,
            WithoutDataCollection = 1
        }

        #endregion
    }
}
