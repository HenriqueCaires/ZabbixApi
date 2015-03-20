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
    public partial class Alert : EntityBase
    {
        #region Properties
        /// <summary>
        /// ID of the alert.
        /// </summary>
        [JsonProperty("alertid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the action that generated the alert.
        /// </summary>
        public string actionid { get; set; }

        /// <summary>
        /// Alert type. 
        /// 
        /// Possible values: 
        /// 0 - message; 
        /// 1 - remote command.
        /// </summary>
        public AlertType alerttype { get; set; }

        /// <summary>
        /// Time when the alert was generated.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// Error text if there are problems sending a message or running a command.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// Action escalation step during which the alert was generated.
        /// </summary>
        public int esc_step { get; set; }

        /// <summary>
        /// ID of the event that triggered the action.
        /// </summary>
        public string eventid { get; set; }

        /// <summary>
        /// ID of the media type that was used to send the message.
        /// </summary>
        public string mediatypeid { get; set; }

        /// <summary>
        /// Message text. Used for message alerts.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Number of times Zabbix tried to send the message.
        /// </summary>
        public int retries { get; set; }

        /// <summary>
        /// Address, user name or other identifier of the recipient. Used for message alerts.
        /// </summary>
        public string sendto { get; set; }

        /// <summary>
        /// Status indicating whether the action operation has been executed successfully. 
        /// 
        /// Possible values for message alerts: 
        /// 0 - message not sent; 
        /// 1 - message sent; 
        /// 2 - failed after a number of retries. 
        /// 
        /// Possible values for command alerts: 
        /// 1 - command run; 
        /// 2 - tried to run the command on the Zabbix agent but it was unavailable.
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Message subject. Used for message alerts.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// ID of the user that the message was sent to.
        /// </summary>
        public string userid { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Hosts
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Media Types
        /// </summary>
        public IList<MediaType> mediatypes  { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public IList<User> users { get; set; }

        #endregion

        #region ENUMS
        public enum AlertType
        {
            Message = 0,
            RemoteCommand = 1
        }
        #endregion
    }
}
