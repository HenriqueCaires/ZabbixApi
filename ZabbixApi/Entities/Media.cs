using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public partial class Media : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the media.
        /// </summary>
        [JsonProperty("mediaid")]
        public override string Id { get; set; }

        /// <summary>
        /// Whether the media is enabled. 
        /// 
        /// Possible values: 
        /// 0 - enabled; 
        /// 1 - disabled.
        /// </summary>
        public Active active { get; set; }

        /// <summary>
        /// ID of the media type used by the media.
        /// </summary>
        public string mediatypeid { get; set; }

        /// <summary>
        /// Time when the notifications can be sent as a time period.
        /// </summary>
        public string period { get; set; }

        /// <summary>
        /// Address, user name or other identifier of the recipient.
        /// </summary>
        public List<string> sendto { get; set; }

        /// <summary>
        /// Trigger severities to send notifications about. 
        /// 
        /// Severities are stored in binary form with each bit representing the corresponding severity. For example, 12 equals 1100 in binary and means, that notifications will be sent from triggers with severities warning and average. 
        /// 
        /// Refer to the trigger object page for a list of supported trigger severities.
        /// </summary>
        public int severity { get; set; }

        /// <summary>
        /// ID of the user that uses the media.
        /// </summary>
        public string userid { get; set; }
        #endregion

        #region ENUMS

        public enum Active
        {
            Enabled = 0,
            Disabled = 1
        }

        #endregion
    }
}
