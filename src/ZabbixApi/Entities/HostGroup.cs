using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

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

        #region Associations

        /// <summary>
        /// LLD rule that created the host group
        /// </summary>
        public DiscoveryRule discoveryRule { get; set; }

        /// <summary>
        /// Host group discovery object
        /// </summary>
        public GroupDiscovery groupDiscovery { get; set; }

        /// <summary>
        /// Hosts that belong to the host group
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Templates that belong to the host group
        /// </summary>
        public IList<Template> templates { get; set; }

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

    public partial class GroupDiscovery
    {
        #region Properties

        /// <summary>
        /// ID of the discovered host group
        /// </summary>
        public string groupid { get; set; }

        /// <summary>
        /// Time when the host group was last discovered
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastcheck { get; set; }

        /// <summary>
        /// Name of the host goup prototype
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ID of the host group prototype from which the host group has been created
        /// </summary>
        public string parent_group_prototypeid { get; set; }

        /// <summary>
        /// Time when a host group that is no longer discovered will be deleted
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime ts_delete { get; set; }

        #endregion
    }
}
