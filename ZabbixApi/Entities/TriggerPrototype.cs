using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class TriggerPrototype : EntityBase
    {
        #region Properties
        
        /// <summary>
        /// (readonly) ID of the trigger prototype.
        /// </summary>
        [JsonProperty("triggerid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the trigger prototype.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Reduced trigger expression.
        /// </summary>
        public string expression { get; set; }

        /// <summary>
        /// Additional comments to the trigger prototype.
        /// </summary>
        public string comments { get; set; }

        /// <summary>
        /// Severity of the trigger prototype. 
        /// 
        /// Possible values: 
        /// 0 - (default) not classified; 
        /// 1 - information; 
        /// 2 - warning; 
        /// 3 - average; 
        /// 4 - high; 
        /// 5 - disaster.
        /// </summary>
        public Severity priority { get; set; }

        /// <summary>
        /// Whether the trigger prototype is enabled or disabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template trigger prototype.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Whether the trigger prototype can generate multiple problem events. 
        /// 
        /// Possible values: 
        /// 0 - (default) do not generate multiple events; 
        /// 1 - generate multiple events.
        /// </summary>
        public MultipleProblemEvents type { get; set; }

        /// <summary>
        /// URL associated with the trigger prototype.
        /// </summary>
        public string url { get; set; }

        #region Properties of Expanded Data

        /// <summary>
        /// Visible name of the host
        /// </summary>
        public string hostname { get; set; }

        /// <summary>
        /// Technical name of the host
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// ID of the host
        /// </summary>
        public string hostid { get; set; }

        #endregion

        #endregion

        #region Associations

        //TODO: verify this name
        /// <summary>
        /// The low-level discovery rule that created the trigger
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<DiscoveryRule>))]
        public DiscoveryRule discoveryrule { get; set; }

        /// <summary>
        /// Functions used in the trigger prototype
        /// </summary>
        public IList<Function> functions { get; set; }

        /// <summary>
        /// The host groups that the trigger prototype belongs to
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// The hosts that the trigger prototype belongs to
        /// </summary>
        public IList<Host> hosts { get; set; }

        //TODO: We need an Inheritance here
        /// <summary>
        /// Items and item prototypes used the trigger prototype
        /// </summary>
        public IList<object> items { get; set; }

        #endregion

        #region ENUMS

        public enum MultipleProblemEvents
        {
            DoNotGenerateMultipleEvents = 0,
            GenerateMultipleEvents = 1
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        public enum Severity
        {
            NotClassified = 0,
            Information = 1,
            Warning = 2,
            Average = 3,
            High = 4,
            Disaster = 5
        }

        #endregion

        #region Constructors

        public TriggerPrototype()
        {
            priority = Severity.NotClassified;
            status = Status.Enabled;
            type = MultipleProblemEvents.DoNotGenerateMultipleEvents;
        }

        #endregion
    }
}
