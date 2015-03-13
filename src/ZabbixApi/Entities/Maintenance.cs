using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public partial class Maintenance
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

        #region Constructors

        public Maintenance()
        {
            active_since = DateTime.Now;
            active_till = DateTime.Today.AddDays(1);
            maintenance_type = MaintenanceType.WithDataCollection;
        }

        #endregion
    }

    public partial class TimePeriod
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the maintenance.
        /// </summary>
        public string timeperiodid { get; set; }

        /// <summary>
        /// Day of the month when the maintenance must come into effect. 
        /// 
        /// Required only for monthly time periods.
        /// </summary>
        public int day { get; set; }

        /// <summary>
        /// Days of the week when the maintenance must come into effect. 
        /// 
        /// Days are stored in binary form with each bit representing the corresponding day. For example, 4 equals 100 in binary and means, that maintenance will be enabled on Wednesday. 
        /// 
        /// Used for weekly and monthly time periods. Required only for weekly time periods.
        /// </summary>
        public int dayofweek { get; set; }

        /// <summary>
        /// For daily and weekly periods every defines day or week intervals at which the maintenance must come into effect. 
        /// 
        /// For monthly periods every defines the week of the month when the maintenance must come into effect. 
        /// Possible values: 
        /// 1 - first week; 
        /// 2 - second week; 
        /// 3 - third week; 
        /// 4 - fourth week; 
        /// 5 - last week.
        /// </summary>
        public Every every { get; set; }

        /// <summary>
        /// Months when the maintenance must come into effect. 
        /// 
        /// Months are stored in binary form with each bit representing the corresponding month. For example, 5 equals 101 in binary and means, that maintenance will be enabled in January and March. 
        /// 
        /// Required only for monthly time periods.
        /// </summary>
        public int month { get; set; }

        /// <summary>
        /// Duration of the maintenance period in seconds. 
        /// 
        /// Default: 3600.
        /// </summary>
        public int period { get; set; }

        /// <summary>
        /// Date when the maintenance period must come into effect. 
        /// 
        /// Required only for one time periods. 
        /// 
        /// Default: current date.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime start_date { get; set; }

        /// <summary>
        /// Time of day when the maintenance starts in seconds. 
        /// 
        /// Required for daily, weekly and monthly periods.
        /// </summary>
        public int start_time { get; set; }

        /// <summary>
        /// Type of time period. 
        /// 
        /// Possible values: 
        /// 0 - (default) one time only; 
        /// 2 - daily; 
        /// 3 - weekly; 
        /// 4 - monthly.
        /// </summary>
        public TimePeriodType timeperiod_type { get; set; }

        #endregion

        #region ENUMS

        public enum TimePeriodType
        {
            OneTimeOnly = 0,
            Daily = 2,
            Weekly = 3,
            Monthly = 4
        }

        public enum Every
        {
            FirstWeek = 1,
            SecondWeek = 2,
            ThirdWeek = 3,
            FourthWeek = 4,
            LastEeek = 5
        }

        #endregion

        #region Constructors

        public TimePeriod()
        {
            period = 3600;
            start_date = DateTime.Today;
            timeperiod_type = TimePeriodType.OneTimeOnly;
        }

        #endregion
    }

}
