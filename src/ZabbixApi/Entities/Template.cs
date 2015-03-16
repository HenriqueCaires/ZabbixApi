using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix.Entities
{
    public partial class Template : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the template.
        /// </summary>
        [JsonProperty("templateid")]
        public override string Id { get; set; }

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

        #endregion
    }
}
