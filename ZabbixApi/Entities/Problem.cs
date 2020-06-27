using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class Problem : EntityBase
    {
        #region Properties
        /// <summary>
        /// ID of the problem event.
        /// </summary>
        [JsonProperty("eventid")]
        public string Id { get; set; }
        /// <summary>
        /// Type of the problem event.
        /// Possible values:
        /// 0 - event created by a trigger
        /// 3 - internal event.
        /// Default: 0 - problem created by a trigger.
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// Type of object that is related to the problem event.
        /// Possible values for trigger events:
        /// 0 - trigger.
        /// Possible values for internal events:
        /// 0 - trigger;
        /// 4 - item;
        /// 5 - LLD rule.
        /// </summary>
        [JsonProperty("object")]
        public string _object { get; set; }
        /// <summary>
        /// ID of the related object.
        /// </summary>
        [JsonProperty("objectid")]
        public string _objectid { get; set; }
        /// <summary>
        /// Time when the problem event was created.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }
        /// <summary>
        /// Nanoseconds when the problem event was created.
        /// </summary>
        public string ns { get; set; }
        /// <summary>
        /// Recovery event ID.
        /// </summary>
        public string r_eventid { get; set; }
        /// <summary>
        /// Time when the recovery event was created.
        /// </summary>
        public string r_clock { get; set; }
        /// <summary>
        /// Nanoseconds when the recovery event was created.
        /// </summary>
        public string r_ns { get; set; }
        /// <summary>
        /// Correlation rule ID if this event was recovered by global correlation rule.
        /// </summary>
        public string correlationid { get; set; }
        /// <summary>
        /// User ID if the problem was manually closed.
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// true - return acknowledged problems only;
        /// false - unacknowledged only.
        /// </summary>
        public string acknowledged { get; set; }
        /// <summary>
        /// Return only problems with given trigger severities. Applies only if object is trigger.
        /// </summary>
        public int severity { get; set; }
        /// <summary>
        /// true - return only suppressed problems;
        /// false - return problems in the normal state.                
        /// </summary>
        public string supressed { get; set; }
        #endregion

        #region Associations
            public IList<Acknowledge> acknowledges { get; set; }

        #endregion
    }
}
