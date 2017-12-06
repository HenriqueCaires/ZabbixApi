using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Entities
{
    public partial class Script : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the script.
        /// </summary>
        [JsonProperty("scriptid")]
        public override string Id { get; set; }

        /// <summary>
        /// Command to run.
        /// </summary>
        public string command { get; set; }

        /// <summary>
        /// Name of the script.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Confirmation pop up text. The pop up will appear when trying to run the script from the Zabbix frontend.
        /// </summary>
        public string confirmation { get; set; }

        /// <summary>
        /// Description of the script.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Where to run the script. 
        /// 
        /// Possible values: 
        /// 0 - run on Zabbix agent; 
        /// 1 - (default) run on Zabbix server.
        /// </summary>
        public ExecuteOn execute_on { get; set; }

        /// <summary>
        /// ID of the host group that the script can be run on. If set to 0, the script will be available on all host groups. 
        /// 
        /// Default: 0.
        /// </summary>
        public string groupid { get; set; }

        /// <summary>
        /// Host permissions needed to run the script. 
        /// 
        /// Possible values: 
        /// 2 - (default) read; 
        /// 3 - write.
        /// </summary>
        public HostAccess host_access { get; set; }

        /// <summary>
        /// Script type. 
        /// 
        /// Possible values: 
        /// 0 - (default) script; 
        /// 1 - IPMI.
        /// </summary>
        public ScriptType type { get; set; }

        /// <summary>
        /// ID of the user group that will be allowed to run the script. If set to 0, the script will be available for all user groups. 
        /// 
        /// Default: 0.
        /// </summary>
        public string usrgrpid { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Host groups that the script can be run on
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// Hosts that the script can be run on
        /// </summary>
        public IList<Host> hosts { get; set; }

        #endregion

        #region ENUMS

        public enum ExecuteOn
        {
            ZabbixAgent = 0,
            ZabbixServer = 1
        }

        public enum HostAccess
        {
            Read = 2,
            Write = 3
        }

        public enum ScriptType
        {
            Script = 0,
            IPMI = 1
        }

        #endregion

        #region Constructors

        public Script()
        {
            execute_on = ExecuteOn.ZabbixServer;
            groupid = "0";
            host_access = HostAccess.Read;
            type = ScriptType.Script;
            usrgrpid = "0";
        }

        #endregion
    }
}
