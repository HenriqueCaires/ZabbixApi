using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class WebScenario : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the web scenario.
        /// </summary>
        [JsonProperty("httptestid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the host that the web scenario belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// Name of the web scenario.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// User agent string that will be used by the web scenario.
        /// </summary>
        public string agent { get; set; }

        /// <summary>
        /// ID of the application that the web scenario belongs to.
        /// </summary>
        public string applicationid { get; set; }

        /// <summary>
        /// Authentication method that will be used by the web scenario. 
        /// 
        /// Possible values: 
        /// 0 - (default) none; 
        /// 1 - basic HTTP authentication; 
        /// 2 - NTLM authentication.
        /// </summary>
        public AuthenticationMethod authentication { get; set; }

        /// <summary>
        /// Execution interval of the web scenario in seconds. 
        /// 
        /// Default: 60.
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// Password used for authentication. 
        /// 
        /// Required for web scenarios with basic HTTP or NTLM authentication.
        /// </summary>
        public string http_password { get; set; }

        /// <summary>
        /// Proxy that will be used by the web scenario given as http://[username[:password]@]proxy.example.com[:port].
        /// </summary>
        public string http_proxy { get; set; }

        /// <summary>
        /// User name used for authentication. 
        /// 
        /// Required for web scenarios with basic HTTP or NTLM authentication.
        /// </summary>
        public string http_user { get; set; }

        /// <summary>
        /// (readonly) Time of the next web scenario execution.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime nextcheck { get; set; }

        /// <summary>
        /// Number of times a web scenario will try to execute each step before failing. 
        /// 
        /// Default: 1.
        /// </summary>
        public int retries { get; set; }

        /// <summary>
        /// Whether the web scenario is enabled. 
        /// 
        /// Possible values are: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template web scenario.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Web scenario variables.
        /// </summary>
        public string variables { get; set; }

        #endregion

        #region ENUMS

        public enum AuthenticationMethod
        {
            None = 0,
            BasicHTTP = 1,
            NTLM = 2
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        #endregion

        #region Constructors

        public WebScenario()
        {
            authentication = AuthenticationMethod.None;
            delay = 60;
            retries = 1;
            status = Status.Enabled;
        }

        #endregion
    }

    public partial class ScenarioStep : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the scenario step.
        /// </summary>
        [JsonProperty("httpstepid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the scenario step.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Sequence number of the step in a web scenario.
        /// </summary>
        public int no { get; set; }

        /// <summary>
        /// URL to be checked.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// (readonly) ID of the web scenario that the step belongs to.
        /// </summary>
        public string httptestid { get; set; }

        /// <summary>
        /// HTTP POST variables as a string.
        /// </summary>
        public string posts { get; set; }

        /// <summary>
        /// Text that must be present in the response.
        /// </summary>
        public string required { get; set; }

        /// <summary>
        /// Ranges of required HTTP status codes separated by commas.
        /// </summary>
        public string status_codes { get; set; }

        /// <summary>
        /// Request timeout in seconds. 
        /// 
        /// Default: 15.
        /// </summary>
        public int timeout { get; set; }

        /// <summary>
        /// Scenario step variables.
        /// </summary>
        public string variables { get; set; }

        #endregion

        #region Constructors

        public ScenarioStep()
        {
            timeout = 15;
        }

        #endregion
    }
}
