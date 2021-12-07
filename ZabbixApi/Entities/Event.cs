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
    public partial class Event : EntityBase
    {
        #region Properties
        /// <summary>
        /// ID of the event.
        /// </summary>
        [JsonProperty("eventid")]
        public override string Id { get; set; }

        /// <summary>
        /// Type of the event. 
        /// 
        /// Possible values: 
        /// 0 - event created by a trigger; 
        /// 1 - event created by a discovery rule; 
        /// 2 - event created by active agent auto-registration; 
        /// 3 - internal event.
        /// </summary>
        public Source source { get; set; }

        /// <summary>
        /// Type of object that is related to the event. 
        /// 
        /// Possible values for trigger events: 
        /// 0 - trigger. 
        /// 
        /// Possible values for discovery events: 
        /// 1 - discovered host; 
        /// 2 - discovered service. 
        /// 
        /// Possible values for auto-registration events: 
        /// 3 - auto-registered host. 
        /// 
        /// Possible values for internal events: 
        /// 0 - trigger; 
        /// 4 - item; 
        /// 5 - LLD rule.
        /// </summary>
        [JsonProperty("object")]
        public int @object { get; set; }

        /// <summary>
        /// ID of the related object.
        /// </summary>
        public string objectid { get; set; }

        /// <summary>
        /// Whether the event has been acknowledged.
        /// </summary>
        public int acknowledged { get; set; }

        /// <summary>
        /// Time when the event was created.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// Nanoseconds when the event was created.
        /// </summary>
        public int ns { get; set; }

        /// <summary>
        /// Resolved event name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// State of the related object. 
        /// 
        /// Possible values for trigger events: 
        /// 0 - OK; 
        /// 1 - problem. 
        /// 
        /// Possible values for discovery events: 
        /// 0 - host or service up; 
        /// 1 - host or service down; 
        /// 2 - host or service discovered; 
        /// 3 - host or service lost. 
        /// 
        /// Possible values for internal events: 
        /// 0 - "normal" state; 
        /// 1 - "unknown" or “not supported” state. 
        /// 
        /// This parameter is not used for active agent auto-registration events.
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// Event current severity. 
        /// 
        /// Possible values: 
        /// 0 - not classified; 
        /// 1 - information; 
        /// 2 - warning; 
        /// 3 - average; 
        /// 4 - high; 
        /// 5 - disaster.
        /// </summary>
        public Severity severity { get; set; }

        /// <summary>
        /// Recovery event ID
        /// </summary>
        public string r_eventid { get; set; }

        /// <summary>
        /// Problem event ID who generated OK event
        /// </summary>
        public string c_eventid { get; set; }

        /// <summary>
        /// Correlation ID
        /// </summary>
        public string correlationid { get; set; }

        /// <summary>
        /// User ID if the event was manually closed.
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// (readonly) Whether the event is suppressed. 
        /// 
        /// Possible values: 
        /// 0 - event is in normal state; 
        /// 1 - event is suppressed.
        /// </summary>
        public Suppressed suppressed { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Hosts
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Return the object that created the event in the relatedObject property. The type of object returned depends on the event type.
        /// </summary>
        public object relatedObject { get; set; }

        /// <summary>
        /// Alerts
        /// </summary>
        public IList<Alert> alerts { get; set; }

        /// <summary>
        /// Acknowledges
        /// </summary>
        public IList<Acknowledge> acknowledges { get; set; }

        public IList<Tag> tags { get; set; }

        public IList<SuppressionData> suppression_data { get; set; }


        #endregion

        #region ENUMS
        public enum Source
        {
            Trigger = 0,
            DiscoveryRule = 1,
            ActiveAgentAutoRegistration = 2,
            InternalEvent = 3
        }

        public enum Severity
        {
            NotClassified = 0,
            Information = 1,
            Warning = 2,
            Average = 3,
            High = 4,
            Disaster = 5,
        }

        public enum Suppressed
        {
            NormalState = 0,
            Suppressed = 1,
        }

        #endregion

        #region ShouldSerialize

        public bool ShouldSerializesuppressed() => false;
        #endregion

    }

    public partial class Acknowledge : EntityBase
    {
        #region Properties

        /// <summary>
        /// acknowledgement's ID
        /// </summary>
        [JsonProperty("acknowledgeid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the user that acknowledged the event
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        ///  ID of the acknowledged event
        /// </summary>
        public string eventid { get; set; }

        /// <summary>
        /// time when the event was acknowledged
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// Text of the acknowledgement message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// alias of the user that acknowledged the event
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// name of the user that acknowledged the event
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// surname of the user that acknowledged the event
        /// </summary>
        public string surname { get; set; }



        #endregion
    }

    public class SuppressionData
    {
        public string maintenanceid { get; set; }

        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime suppress_until { get; set; }
    }
}
