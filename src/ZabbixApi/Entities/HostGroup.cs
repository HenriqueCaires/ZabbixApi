using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;

namespace ZabbixApi.Entities
{
    public partial class HostGroup : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the host group.
        /// </summary>
        [JsonProperty("groupid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the host group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (readonly) Origin of the host group.
        /// 
        /// Possible values: 
        /// 0 - a plain host group; 
        /// 4 - a discovered host group.
        /// </summary>
        public Flags flags { get; set; }

        /// <summary>
        /// (readonly) Whether the group is used internally by the system. An internal group cannot be deleted. 
        /// 
        /// Possible values: 
        /// 0 - (default) not internal; 
        /// 1 - internal.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        [JsonProperty("internal")]
        public bool @internal { get; set; }
        #endregion

        #region ENUMS
        public enum Flags
        {
            PlainHostGroup = 0,
            DiscoveredHostGroup = 4
        }
        #endregion

        #region Constructors

        public HostGroup()
        {
            @internal = false;
        }

        #endregion

    }
}
