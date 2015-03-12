using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class IconMap
    {
        /// <summary>
        /// (readonly) ID of the icon map.
        /// </summary>
        public string iconmapid { get; set; }

        /// <summary>
        /// ID of the default icon.
        /// </summary>
        public string default_iconid { get; set; }

        /// <summary>
        /// Name of the icon map.
        /// </summary>
        public string name { get; set; }
    }
}
