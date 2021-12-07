using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        /// Default: 1m.
        /// </summary>
        public string delay { get; set; }

        /// <summary>
        /// HTTP headers that will be sent when performing a request. Scenario step headers will overwrite headers specified for the web scenario. 
        /// </summary>
        public IList<HttpField> headers { get; set; }

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
        public DateTime? nextcheck { get; }

        /// <summary>
        /// Number of times a web scenario will try to execute each step before failing. 
        /// 
        /// Default: 1.
        /// </summary>
        public int retries { get; set; }

        /// <summary>
        /// Name of the SSL certificate file used for client authentication (must be in PEM format).
        /// </summary>
        public string ssl_cert_file { get; set; }

        /// <summary>
        /// Name of the SSL private key file used for client authentication (must be in PEM format).
        /// </summary>
        public string ssl_key_file { get; set; }

        /// <summary>
        /// SSL private key password.
        /// </summary>
        public string ssl_key_password { get; set; }

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
        public IList<HttpField> variables { get; set; }

        /// <summary>
        /// Whether to verify that the host name specified in the SSL certificate matches the one used in the scenario. 
        /// 
        /// 0 - (default) skip peer verification; 
        /// 1 - verify peer.
        /// </summary>
        public Verify verify_host { get; set; }

        /// <summary>
        /// Whether to verify the SSL certificate of the web server. 
        /// 
        /// 0 - (default) skip peer verification; 
        /// 1 - verify peer.
        /// </summary>
        public Verify verify_peer { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Host that the item belongs to as an array
        /// </summary>
        public IList<ScenarioStep> steps { get; set; }

        
        /// <summary>
        /// Web scenario tags.
        /// </summary>
        public IList<Tag> tags { get; set; }

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
            delay = "1m";
            retries = 1;
            status = Status.Enabled;
            verify_host = Verify.DoNotValidate;
            verify_peer = Verify.DoNotValidate;
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
        /// Whether to follow HTTP redirects. 
        /// 
        /// 0 - don't follow redirects; 
        /// 1 - (default) follow redirects.
        /// </summary>
        public FollowRedirects follow_redirects { get; set; }

        /// <summary>
        /// (readonly) ID of the web scenario that the step belongs to.
        /// </summary>
        public string httptestid { get; set; }

        /// <summary>
        /// HTTP POST variables as HTTP fields.
        /// </summary>
        public IList<HttpField> posts { get; set; }

        /// <summary>
        /// Text that must be present in the response.
        /// </summary>
        public string required { get; set; }

        /// <summary>
        /// HTTP agent item field. What part of response should be stored.
        /// 
        /// 0 - (default) Body.
        /// 1 - Headers.
        /// 2 - Both body and headers will be stored.
        /// 
        /// For request_method HEAD only 1 is allowed value.
        /// </summary>
        public RetrieveMode retrieve_mode { get; set; }

        /// <summary>
        /// Ranges of required HTTP status codes separated by commas.
        /// </summary>
        public string status_codes { get; set; }

        /// <summary>
        /// Request timeout in seconds. 
        /// 
        /// Default: 15.
        /// </summary>
        public string timeout { get; set; }

        /// <summary>
        /// Scenario step variables.
        /// </summary>
        public IList<HttpField> variables { get; set; }

        /// <summary>
        /// Query fields - array of HTTP fields that will be added to URL when performing a request
        /// </summary>
        public IList<HttpField> query_fields { get; set; }

        #endregion

        #region Constructors

        public ScenarioStep()
        {
            follow_redirects = FollowRedirects.FollowRedirects;
            retrieve_mode = RetrieveMode.Body;
            timeout = "15s";
        }

        #endregion
    }

    /// <summary>
    /// HTTP field
    /// 
    /// The HTTP field object defines a name and value that is used to specify variable, HTTP header, POST form field data of query field data.
    /// </summary>
    public class HttpField
    {
        /// <summary>
        /// Name of header / variable / POST or GET field.
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// Value of header / variable / POST or GET field.
        /// </summary>
        public string value { get; set; }
    }
}
