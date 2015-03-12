using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class HostPrototype
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the host prototype.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// Technical name of the host prototype.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Visible name of the host prototype. 
        /// 
        /// Default: host property value.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Status of the host prototype. 
        /// 
        /// Possible values are:
        /// 0 - (default) monitored host;
        /// 1 - unmonitored host.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template host prototype.
        /// </summary>
        public string templateid { get; set; }
        #endregion

        #region ENUMS

        public enum Status
        {
            Monitored = 0,
            Unmonitored = 1
        }

        #endregion
    }
}
