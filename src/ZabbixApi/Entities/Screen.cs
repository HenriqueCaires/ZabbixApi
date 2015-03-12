using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class Screen
    {
        /// <summary>
        /// (readonly) ID of the screen.
        /// </summary>
        public string screenid { get; set; }

        /// <summary>
        /// Name of the screen.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Width of the screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int hsize { get; set; }

        /// <summary>
        /// Height of the screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int vsize { get; set; }

    }
}
