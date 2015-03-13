using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class Action
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

        #region Associations

        public IList<ActionCondition> conditions { get; set; }

        public IList<ActionOperation> operations { get; set; }

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

        #region Constructors

        public Action()
        {
            recovery_msg = RecoveryMessageStatus.Disabled;
            status = Status.Enabled;
        }

        #endregion

    }

    public partial class ActionCondition
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the action condition.
        /// </summary>
        public string conditionid { get; set; }

        /// <summary>
        /// Type of condition. 
        /// 
        /// Possible values for trigger actions: 
        /// 0 - host group; 
        /// 1 - host; 
        /// 2 - trigger; 
        /// 3 - trigger name; 
        /// 4 - trigger severity; 
        /// 5 - trigger value; 
        /// 6 - time period; 
        /// 13 - host template; 
        /// 15 - application; 
        /// 16 - maintenance status; 
        /// 17 - node. 
        /// 
        /// Possible values for discovery actions: 
        /// 7 - host IP; 
        /// 8 - discovered service type; 
        /// 9 - discovered service port; 
        /// 10 - discovery status; 
        /// 11 - uptime or downtime duration; 
        /// 12 - received value; 
        /// 18 - discovery rule; 
        /// 19 - discovery check; 
        /// 20 - proxy; 
        /// 21 - discovery object. 
        /// 
        /// Possible values for auto-registration actions: 
        /// 20 - proxy; 
        /// 22 - host name; 
        /// 24 - host metadata. 
        /// 
        /// Possible values for internal actions: 
        /// 0 - host group; 
        /// 1 - host; 
        /// 13 - host template; 
        /// 15 - application; 
        /// 23 - event type; 
        /// 17 - node.
        /// </summary>
        public ConditionType conditiontype { get; set; }

        /// <summary>
        /// Value to compare with.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// (readonly) ID of the action that the condition belongs to.
        /// </summary>
        public string actionid { get; set; }

        /// <summary>
        /// Condition operator. 
        /// 
        /// Possible values: 
        /// 0 - (default) =; 
        /// 1 - <>; 
        /// 2 - like; 
        /// 3 - not like; 
        /// 4 - in; 
        /// 5 - >=; 
        /// 6 - <=;
        /// 7 - not in.
        /// </summary>
        [JsonProperty("operator")]
        public ConditionOperator @operator { get; set; }

        #endregion

        #region ENUMS

        public enum ConditionType
        {
            HostGroup = 0,
            Host = 1,
            Trigger = 2,
            TriggerName = 3,
            TriggerSeverity = 4,
            TriggerValue = 5,
            TimePeriod = 6,
            HostIP = 7,
            DiscoveredServiceType = 8,
            DiscoveredServicePort = 9,
            DiscoveryStatus = 10,
            UptimeOrDowntimeDuration = 11,
            ReceivedValue = 12,
            HostTemplate = 13,
            Application = 15,
            MaintenanceStatus = 16,
            Node = 17,
            DiscoveryRule = 18,
            DiscoveryCheck = 19,
            Proxy = 20,
            DiscoveryObject = 21,
            HostName = 22,
            EventType = 23,
            HostMetadata = 24,
        }

        public enum ConditionOperator
        {
            Equal = 0,
            NotEqual = 1,
            Like = 2,
            NotLike = 3,
            In = 4,
            GreaterOrEqual = 5,
            LessOrEqual = 6,
            NotIn = 7
        }
        #endregion

        #region Constructors

        public ActionCondition()
        {
            @operator = ConditionOperator.Equal;
        }

        #endregion
    }

    public partial class ActionOperation
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the action operation.
        /// </summary>
        public string operationid { get; set; }

        /// <summary>
        /// Type of operation. 
        /// 
        /// Possible values: 
        /// 0 - send message; 
        /// 1 - remote command; 
        /// 2 - add host; 
        /// 3 - remove host; 
        /// 4 - add to host group; 
        /// 5 - remove from host group; 
        /// 6 - link to template; 
        /// 7 - unlink from template; 
        /// 8 - enable host; 
        /// 9 - disable host.
        /// </summary>
        public OperationType operationtype { get; set; }

        /// <summary>
        /// ID of the action that the operation belongs to.
        /// </summary>
        public string actionid { get; set; }

        /// <summary>
        /// Duration of an escalation step in seconds. Must be greater than 60 seconds. If set to 0, the default action escalation period will be used. 
        /// 
        /// Default: 0.
        /// </summary>
        public int esc_period { get; set; }

        /// <summary>
        /// Step to start escalation from. 
        /// 
        /// Default: 1.
        /// </summary>
        public int esc_step_from { get; set; }

        /// <summary>
        /// Step to end escalation at. 
        /// 
        /// Default: 1.
        /// </summary>
        public int esc_step_to { get; set; }

        /// <summary>
        /// Operation condition evaluation method. 
        /// 
        /// Possible values: 
        /// 0 - (default) AND / OR; 
        /// 1 - AND; 
        /// 2 - OR.
        /// </summary>
        public ConditionOperation evaltype { get; set; }

        /// <summary>
        /// Object containing the data about the command run by the operation. 
        /// 
        /// The operation command object is described in detail below. 
        /// 
        /// Required for remote command operations.
        /// </summary>
        public ActionOperationCommand opcommand { get; set; }

        /// <summary>
        /// Host groups to run remote commands on. 
        /// 
        /// Each object has the following properties: 
        /// opcommand_grpid - (string, readonly) ID of the object; 
        /// operationid - (string) ID of the operation; 
        /// groupid - (string) ID of the host group. 
        /// 
        /// Required for remote command operations if opcommand_hst is not set.
        /// </summary>
        public IList<OperationCommandGroup> opcommand_grp { get; set; }

        /// <summary>
        /// Host to run remote commands on. 
        /// 
        /// Each object has the following properties: 
        /// opcommand_hstid - (string, readonly) ID of the object; 
        /// operationid - (string) ID of the operation; 
        /// hostid - (string) ID of the host; if set to 0 the command will be run on the current host. 
        /// 
        /// Required for remote command operations if opcommand_grp is not set.
        /// </summary>
        public IList<OperationCommandHost> opcommand_hst { get; set; }

        /// <summary>
        /// Operation conditions used for trigger actions. 
        /// 
        /// The operation condition object is described in detail below.
        /// </summary>
        public IList<ActionOperationCondition> opconditions { get; set; }

        /// <summary>
        /// Host groups to add hosts to. 
        /// 
        /// Each object has the following properties: 
        /// operationid - (string) ID of the operation; 
        /// groupid - (string) ID of the host group. 
        /// 
        /// Required for “add to host group” and “remove from host group” operations.
        /// </summary>
        public IList<OperationGroup> opgroup { get; set; }

        /// <summary>
        /// Object containing the data about the message sent by the operation. 
        /// 
        /// The operation message object is described in detail below. 
        /// 
        /// Required for message operations.
        /// </summary>
        public ActionOperationMessage opmessage { get; set; }

        /// <summary>
        /// User groups to send messages to. 
        /// 
        /// Each object has the following properties: 
        /// operationid - (string) ID of the operation; 
        /// usrgrpid - (string) ID of the user group. 
        /// 
        /// Required for message operations if opmessage_usr is not set.
        /// </summary>
        public IList<OperationMessageGroup> opmessage_grp { get; set; }

        /// <summary>
        /// Users to send messages to. 
        /// 
        /// Each object has the following properties: 
        /// operationid - (string) ID of the operation; 
        /// userid - (string) ID of the user. 
        /// 
        /// Required for message operations if opmessage_grp is not set.
        /// </summary>
        public IList<OperationMessageUser> opmessage_usr { get; set; }

        /// <summary>
        /// Templates to link the hosts to to. 
        /// 
        /// Each object has the following properties: 
        /// operationid - (string) ID of the operation; 
        /// templateid - (string) ID of the template. 
        /// 
        /// Required for “link to template” and “unlink from template” operations.
        /// </summary>
        public IList<OperationTemplate> optemplate { get; set; }

        #endregion

        #region ENUMS

        public enum OperationType
        {
            SendMessage = 0,
            RemoteCommand = 1,
            AddHost = 2,
            RemoveHost = 3,
            AddToHostGroup = 4,
            RemoveFromHostGroup = 5,
            LinkToTemplate = 6,
            UnlinkFromTemplate = 7,
            EnableHost = 8,
            DisableHost = 9
        }

        public enum ConditionOperation
        {
            AndOr = 0,
            And = 1,
            Or = 2
        }

        #endregion

        #region Nested classes

        public partial class OperationCommandGroup
        {
            /// <summary>
            /// (readonly) ID of the object; 
            /// </summary>
            public string opcommand_grpid { get; set; }

            /// <summary>
            /// ID of the operation; 
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the host group. 
            /// </summary>
            public string groupid { get; set; }
        }

        public partial class OperationCommandHost
        {
            /// <summary>
            /// (readonly) ID of the object;
            /// </summary>
            public string opcommand_hstid { get; set; }

            /// <summary>
            /// ID of the operation;
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the host; if set to 0 the command will be run on the current host.
            /// </summary>
            public string hostid { get; set; }
        }

        public partial class OperationGroup
        {
            /// <summary>
            /// ID of the operation;
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the host group. 
            /// </summary>
            public string groupid { get; set; }
        }

        public partial class OperationMessageGroup
        {
            /// <summary>
            /// ID of the operation; 
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the user group.
            /// </summary>
            public string usrgrpid { get; set; }
        }

        public partial class OperationMessageUser
        {
            /// <summary>
            /// ID of the operation;
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the user.
            /// </summary>
            public string userid { get; set; }
        }

        public partial class OperationTemplate
        {
            /// <summary>
            /// ID of the operation;
            /// </summary>
            public string operationid { get; set; }

            /// <summary>
            /// ID of the template.
            /// </summary>
            public string templateid { get; set; }
        }

        #endregion

        #region Constructors

        public ActionOperation()
        {
            esc_period = 0;
            esc_step_from = 1;
            esc_step_to = 1;
            evaltype = ConditionOperation.AndOr;
        }

        #endregion
    }

    public partial class ActionOperationCommand
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the operation.
        /// </summary>
        public string operationid { get; set; }

        /// <summary>
        /// Command to run.
        /// </summary>
        public string command { get; set; }

        /// <summary>
        /// Type of operation command. 
        /// 
        /// Possible values: 
        /// 0 - custom script; 
        /// 1 - IPMI; 
        /// 2 - SSH; 
        /// 3 - Telnet; 
        /// 4 - global script.
        /// </summary>
        public OperationCommandType type { get; set; }

        /// <summary>
        /// Authentication method used for SSH commands. 
        /// 
        /// Possible values: 
        /// 0 - password; 
        /// 1 - public key. 
        /// 
        /// Required for SSH commands.
        /// </summary>
        public SSHAuthenticationMethod authtype { get; set; }

        /// <summary>
        /// Target on which the custom script operation command will be executed. 
        /// 
        /// Possible values: 
        /// 0 - Zabbix agent; 
        /// 1 - Zabbix server. 
        /// 
        /// Required for custom script commands.
        /// </summary>
        public ExecuteOn execute_on { get; set; }

        /// <summary>
        /// Password used for SSH commands with password authentication and Telnet commands.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Port number used for SSH and Telnet commands.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// Name of the private key file used for SSH commands with public key authentication. 
        /// 
        /// Required for SSH commands with public key authentication.
        /// </summary>
        public string privatekey { get; set; }

        /// <summary>
        /// Name of the public key file used for SSH commands with public key authentication. 
        /// 
        /// Required for SSH commands with public key authentication.
        /// </summary>
        public string publickey { get; set; }

        /// <summary>
        /// ID of the script used for global script commands. 
        /// 
        /// Required for global script commands.
        /// </summary>
        public string scriptid { get; set; }

        /// <summary>
        /// User name used for authentication. 
        /// 
        /// Required for SSH and Telnet commands.
        /// </summary>
        public string username { get; set; }

        #endregion

        #region ENUMS

        public enum OperationCommandType
        {
            CustomScript = 0,
            IPMI = 1,
            SSH = 2,
            Telnet = 3,
            GlobalScript = 4
        }

        public enum SSHAuthenticationMethod
        {
            Password = 0,
            PublicKey = 1
        }

        public enum ExecuteOn
        {
            ZabbixAgent = 0,
            ZabbixServer = 1
        }

        #endregion

    }

    public partial class ActionOperationCondition
    {
        #region Properties
        
        /// <summary>
        /// (readonly) ID of the action operation condition
        /// </summary>
        public string opconditionid { get; set; }

        /// <summary>
        /// Type of condition. 
        /// 
        /// Possible values: 
        /// 14 - event acknowledged.
        /// </summary>
        public ConditionType conditiontype { get; set; }

        /// <summary>
        /// Value to compare with.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// (readonly) ID of the operation.
        /// </summary>
        public string operationid { get; set; }

        /// <summary>
        /// Condition operator. 
        /// 
        /// Possible values: 
        /// 0 - (default) =.
        /// </summary>
        [JsonProperty("operator")]
        public ConditionOperator @operator { get; set; }

        #endregion

        #region ENUMS
        
        public enum ConditionType
        {
            EventAcknowledged = 14
        }

        public enum ConditionOperator
        {
            Equal = 0
        }

        #endregion

        #region Constructors

        public ActionOperationCondition()
        {
            @operator = ConditionOperator.Equal;
        }

        #endregion
    }

    public partial class ActionOperationMessage
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the action operation.
        /// </summary>
        public string operationid { get; set; }

        /// <summary>
        /// Whether to use the default action message text and subject. 
        /// 
        /// Possible values: 
        /// 0 - (default) use the data from the operation; 
        /// 1 - use the data from the action.
        /// </summary>
        public DefaultActionMessage default_msg { get; set; }

        /// <summary>
        /// ID of the media type that will be used to send the message.
        /// </summary>
        public string mediatypeid { get; set; }

        /// <summary>
        /// Operation message text.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Operation message subject.
        /// </summary>
        public string subject { get; set; }

        #endregion

        #region ENUMS

        public enum DefaultActionMessage
        {
            UseDataFromOperation = 0,
            UseDataFromAction = 1
        }

        #endregion

        #region Constructors

        public ActionOperationMessage()
        {
            default_msg = DefaultActionMessage.UseDataFromOperation;
        }

        #endregion
    }
}
