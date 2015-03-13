using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class Template
    {
        /// <summary>
        /// (readonly) ID of the template.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Technical name of the template.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Visible name of the host. 
        /// 
        /// Default: host property value.
        /// </summary>
        public string name { get; set; }

    }
}
