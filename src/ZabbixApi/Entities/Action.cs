using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class Action
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the action.
        /// </summary>
        public string actionid { get; set; }

        /// <summary>
        /// Default operation step duration. Must be greater than 60 seconds.
        /// </summary>
        public int esc_period { get; set; }

        /// <summary>
        /// Action condition evaluation method. 
        /// 
        /// Possible values: 
        /// 0 - AND / OR; 
        /// 1 - AND; 
        /// 2 - OR.
        /// </summary>
        public EvalType evaltype { get; set; }

        /// <summary>
        /// (constant) Type of events that the action will handle. 
        /// 
        /// Refer to the event "source" property for a list of supported event types.
        /// </summary>
        public int eventsource { get; set; }

        /// <summary>
        /// Name of the action.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Problem message text.
        /// </summary>
        public string def_longdata { get; set; }

        /// <summary>
        /// Problem message subject.
        /// </summary>
        public string def_shortdata { get; set; }

        /// <summary>
        /// Recovery message text.
        /// </summary>
        public string r_longdata { get; set; }

        /// <summary>
        /// Recovery message subject.
        /// </summary>
        public string r_shortdata { get; set; }

        /// <summary>
        /// Whether recovery messages are enabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) disabled; 
        /// 1 - enabled.
        /// </summary>
        public RecoveryMessageStatus recovery_msg { get; set; }

        /// <summary>
        /// Whether the action is enabled or disabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }
        #endregion

        #region ENUMS
        public enum EvalType
        {
            AndOr = 0,
            And = 1,
            Or = 2
        }

        public enum RecoveryMessageStatus
        {
            Disabled = 0,
            Enabled = 1
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }
        #endregion
    }
}
