using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class Trigger : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the trigger.
        /// </summary>
        [JsonProperty("triggerid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the trigger.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Reduced trigger expression.
        /// </summary>
        public string expression { get; set; }

        /// <summary>
        /// Additional comments to the trigger.
        /// </summary>
        public string comments { get; set; }

        /// <summary>
        /// (readonly) Error text if there have been any problems when updating the state of the trigger.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// (readonly) Origin of the trigger. 
        /// 
        /// Possible values are: 
        /// 0 - (default) a plain trigger; 
        /// 4 - a discovered trigger.
        /// </summary>
        public Flags flags { get; set; }

        /// <summary>
        /// (readonly) Time when the trigger last changed its state.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastchange { get; set; }

        /// <summary>
        /// Severity of the trigger. 
        /// 
        /// Possible values are: 
        /// 0 - (default) not classified; 
        /// 1 - information; 
        /// 2 - warning; 
        /// 3 - average; 
        /// 4 - high; 
        /// 5 - disaster.
        /// </summary>
        public Severity priority { get; set; }

        /// <summary>
        /// (readonly) State of the trigger. 
        /// 
        /// Possible values: 
        /// 0 - (default) trigger state is up to date; 
        /// 1 - current trigger state is unknown.
        /// </summary>
        public State state { get; set; }

        /// <summary>
        /// Whether the trigger is enabled or disabled. 
        /// 
        /// Possible values are: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template trigger.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Whether the trigger can generate multiple problem events. 
        /// 
        /// Possible values are: 
        /// 0 - (default) do not generate multiple events; 
        /// 1 - generate multiple events.
        /// </summary>
        public MultipleProblemEvents type { get; set; }

        /// <summary>
        /// URL associated with the trigger.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// (readonly) Whether the trigger is in OK or problem state. 
        /// 
        /// Possible values are: 
        /// 0 - (default) OK; 
        /// 1 - problem.
        /// </summary>
        public TriggerState value { get; set; }

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

        /// <summary>
        /// The host groups that the trigger belongs to
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// The hosts that the trigger belongs to
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Items contained by the trigger
        /// </summary>
        public IList<Item> items { get; set; }

        /// <summary>
        /// Functions used in the trigger
        /// </summary>
        public IList<Function> functions { get; set; }

        /// <summary>
        /// Triggers that the trigger depends
        /// </summary>
        public IList<Trigger> dependencies { get; set; }

        //TODO: verify this name
        /// <summary>
        /// The low-level discovery rule that created the trigger
        /// </summary>
        public DiscoveryRule discoveryrule { get; set; }

        /// <summary>
        /// The last significant trigger event
        /// </summary>
        public Event lastEvent { get; set; }

        #endregion

        #region ENUMS

        public enum Flags
        {
            PlainTrigger = 0,
            DiscoveredTrigger = 4
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

        public enum State
        {
            UpToDate = 0,
            Unknown = 1
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        public enum MultipleProblemEvents
        {
            DoNotGenerateMultipleEvents = 0,
            GenerateMultipleEvents = 1
        }

        public enum TriggerState
        {
            Ok = 0,
            Problem = 1
        }

        #endregion

        #region Constructors

        public Trigger()
        {
            flags = Flags.PlainTrigger;
            priority = Severity.NotClassified;
            state = State.UpToDate;
            status = Status.Enabled;
            type = MultipleProblemEvents.DoNotGenerateMultipleEvents;
            value = TriggerState.Ok;
        }

        #endregion
    }

    public class Function : EntityBase
    {
        #region Properties

        /// <summary>
        /// ID of the function
        /// </summary>
        [JsonProperty("functionid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the item used in the function
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// Name of the function
        /// </summary>
        public string function { get; set; }

        /// <summary>
        /// Parameter passed to the function
        /// </summary>
        public string parameter { get; set; }

        #endregion
    }
}
