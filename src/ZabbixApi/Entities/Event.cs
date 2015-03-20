using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace Zabbix.Entities
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
        /// 0 - “normal” state; 
        /// 1 - “unknown” or “not supported” state. 
        /// 
        /// This parameter is not used for active agent auto-registration events.
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// Whether the state of the related object has changed since the previous event.
        /// </summary>
        public int value_changed { get; set; }
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

        #endregion

        #region ENUMS
        public enum Source
        {
            Trigger = 0,
            DiscoveryRule = 1,
            ActiveAgentAutoRegistration = 2,
            InternalEvent = 3
        }
        #endregion
    }

    public partial class Acknowledge : EntityBase
    {
        #region Properties

        /// <summary>
        /// acknowledgement's ID
        /// </summary>
        [JsonProperty("acknowledgeid")]
        public string Id { get; set; }

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
}
