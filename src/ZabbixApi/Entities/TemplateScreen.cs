using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class TemplateScreen
    {
        /// <summary>
        /// (readonly) ID of the template screen.
        /// </summary>
        public string screenid { get; set; }

        /// <summary>
        /// Name of the template screen.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ID of the template that the screen belongs to.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Width of the template screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int hsize { get; set; }

        /// <summary>
        /// Height of the template screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int vsize { get; set; }

    }
}
