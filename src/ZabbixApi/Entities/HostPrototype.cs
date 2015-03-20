using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace Zabbix.Entities
{
    public partial class HostPrototype : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the host prototype.
        /// </summary>
        [JsonProperty("hostid")]
        public override string Id { get; set; }

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

        #region Associations

        /// <summary>
        /// LLD rule that the host prototype belongs to
        /// </summary>
        public DiscoveryRule discoveryRule { get; set; }

        /// <summary>
        /// Group links of the host prototype
        /// </summary>
        public IList<GroupLink> groupLinks { get; set; }

        /// <summary>
        /// Group prototypes of the host prototype
        /// </summary>
        public IList<GroupPrototype> groupPrototypes { get; set; }

        /// <summary>
        /// Host that the host prototype belongs
        /// </summary>
        public Host parentHost { get; set; }

        /// <summary>
        /// Templates linked to the host prototype
        /// </summary>
        public IList<Template> templates { get; set; }

        #endregion

        #region ENUMS

        public enum Status
        {
            Monitored = 0,
            Unmonitored = 1
        }

        #endregion

        #region Constructors

        public HostPrototype()
        {
            status = Status.Monitored;
        }

        #endregion
    }

    public partial class GroupLink : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the group link.
        /// </summary>
        [JsonProperty("group_prototypeid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the host group.
        /// </summary>
        public string groupid { get; set; }

        /// <summary>
        /// (readonly) ID of the host prototype
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template group link.
        /// </summary>
        public string templateid { get; set; }

        #endregion
    }

    public partial class GroupPrototype : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the group prototype.
        /// </summary>
        [JsonProperty("group_prototypeid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the group prototype.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (readonly) ID of the host prototype
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template group prototype
        /// </summary>
        public string templateid { get; set; }

        #endregion
    }
}
