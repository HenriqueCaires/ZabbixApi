using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class Application
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the application.
        /// </summary>
        public string applicationid { get; set; }

        /// <summary>
        /// ID of the host that the application belongs to. 
        /// 
        /// Cannot be updated.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// Name of the application
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (readonly) IDs of the parent template applications.
        /// </summary>
        public IList<string> templateids { get; set; }
        #endregion
    }
}
