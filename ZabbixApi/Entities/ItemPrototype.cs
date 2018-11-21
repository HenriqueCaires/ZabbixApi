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
    public partial class ItemPrototype : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the item prototype.
        /// </summary>
        [JsonProperty("itemid")]
        public override string Id { get; set; }

        /// <summary>
        /// Update interval of the item prototype in seconds.
        /// </summary>
        public string delay { get; set; }

        /// <summary>
        /// ID of the host that the item prototype belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// ID of the LLD rule that the item belongs to. 
        /// 
        /// For update operations this field is readonly.
        /// </summary>
        public string ruleid { get; set; }

        /// <summary>
        /// ID of the item prototype's host interface. Used only for host item prototypes. 
        /// 
        /// Optional for Zabbix agent (active), Zabbix internal, Zabbix trapper, Zabbix aggregate, database monitor and calculated item prototypes.
        /// </summary>
        public string interfaceid { get; set; }

        /// <summary>
        /// Item prototype key.
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// Name of the item prototype.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Type of the item prototype. 
        /// 
        /// Possible values: 
        /// 0 - Zabbix agent; 
        /// 1 - SNMPv1 agent; 
        /// 2 - Zabbix trapper; 
        /// 3 - simple check; 
        /// 4 - SNMPv2 agent; 
        /// 5 - Zabbix internal; 
        /// 6 - SNMPv3 agent; 
        /// 7 - Zabbix agent (active); 
        /// 8 - Zabbix aggregate; 
        /// 10 - external check; 
        /// 11 - database monitor; 
        /// 12 - IPMI agent; 
        /// 13 - SSH agent; 
        /// 14 - TELNET agent; 
        /// 15 - calculated; 
        /// 16 - JMX agent; 
        /// 17 - SNMP trap.
        /// </summary>
        public ItemPrototypeType type { get; set; }

        /// <summary>
        /// URL string required only for HTTP agent item prototypes. Supports LLD macros, user macros, {HOST.IP}, {HOST.CONN}, {HOST.DNS}, {HOST.HOST}, {HOST.NAME}, {ITEM.ID}, {ITEM.KEY}.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Type of information of the item prototype. 
        /// 
        /// Possible values: 
        /// 0 - numeric float; 
        /// 1 - character; 
        /// 2 - log; 
        /// 3 - numeric unsigned; 
        /// 4 - text.
        /// </summary>
        public ValueType value_type { get; set; }

        /// <summary>
        /// Used only by SSH agent items or HTTP agent items. 
        /// 
        /// SSH agent authentication method possible values: 
        /// 0 - (default) password; 
        /// 1 - public key.
        /// 
        /// HTTP agent authentication method possible values:
        /// 0 - (default) none
        /// 1 - basic
        /// 2 - NTLM
        public AuthenticationMethod authtype { get; set; }

        /// <summary>
        /// Description of the item prototype.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// (readonly) Error text if there are problems updating the item.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// (readonly) Origin of the item. 
        /// 
        /// Possible values: 
        /// 0 - a plain item; 
        /// 4 - a discovered item.
        /// </summary>
        public Flags flags { get; set; }

        /// <summary>
        /// HTTP agent item field. Follow respose redirects while pooling data.
        /// 
        /// 0 - Do not follow redirects.
        /// 1 - (default) Follow redirects.
        /// </summary>
        public FollowRedirects follow_redirects { get; set; }

        /// <summary>
        /// HTTP agent item prototype field. Object with HTTP(S) request headers, where header name is used as key and header value as value. 
        /// 
        /// Example: 
        /// { "User-Agent": "Zabbix" }
        /// </summary>
        public IList<Dictionary<string, string>> headers { get; set; }

        /// <summary>
        /// Number of days to keep item prototype's history data. 
        /// 
        /// Default: 90.
        /// </summary>
        public string history { get; set; }

        /// <summary>
        /// HTTP agent item field. HTTP(S) proxy connection string.
        /// </summary>
        public string http_proxy { get; set; }

        /// <summary>
        /// IPMI sensor. Used only by IPMI item prototypes.
        /// </summary>
        public string ipmi_sensor { get; set; }

        /// <summary>
        /// JMX agent custom connection string. 
        /// 
        /// Default value: 
        /// service:jmx:rmi:///jndi/rmi://{HOST.CONN}:{HOST.PORT}/jmxrmi
        /// </summary>
        public string jmx_endpoint { get; set; }

        /// <summary>
        /// Format of the time in log entries. Used only by log item prototypes.
        /// </summary>
        public string logtimefmt { get; set; }

        /// <summary>
        /// Master item ID.
        /// Recursion up to 3 dependent items and maximum count of dependent items equal to 999 are allowed.
        /// 
        /// Required by Dependent items.
        /// </summary>
        public int master_itemid { get; set; }

        /// <summary>
        /// HTTP agent item field. Should response converted to JSON.
        /// 
        /// 0 - (default) Store raw.
        /// 1 - Convert to JSON
        /// </summary>
        public OutputFormat output_format { get; set; }

        /// <summary>
        /// Additional parameters depending on the type of the item prototype: 
        /// - executed script for SSH and Telnet item prototypes; 
        /// - SQL query for database monitor item prototypes; 
        /// - formula for calculated item prototypes.
        /// </summary>
        [JsonProperty("params")]
        public string @params { get; set; }

        /// <summary>
        /// Password for authentication. Used by simple check, SSH, Telnet, database monitor and JMX item prototypes.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Port monitored by the item prototype. Used only by SNMP items prototype.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// HTTP agent item field. Type of post data body stored in posts property.
        /// 
        /// 0 - (default) Raw data.
        /// 2 - JSON data. 
        /// 3 - XML data.
        /// </summary>
        public PostType post_type { get; set; }

        /// <summary>
        /// HTTP agent item field. HTTP(S) request body data. Used with post_type.
        /// </summary>
        public string posts { get; set; }

        /// <summary>
        /// Name of the private key file.
        /// </summary>
        public string privatekey { get; set; }

        /// <summary>
        /// Name of the public key file.
        /// </summary>
        public string publickey { get; set; }

        /// <summary>
        /// HTTP agent item field. Query parameters. Array of objects with 'key':'value' pairs, where value can be empty string.
        /// </summary>
        public IList<Dictionary<string, string>> query_fields { get; set; }

        /// <summary>
        /// HTTP agent item field. Type of request method.
        /// 
        /// 0 - (default) GET 
        /// 1 - POST 
        /// 2 - PUT 
        /// 3 - HEAD
        /// </summary>
        public RequestMethod request_method { get; set; }

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
        /// SNMP community. 
        /// 
        /// Used only by SNMPv1 and SNMPv2 item prototypes.
        /// </summary>
        public string snmp_community { get; set; }

        /// <summary>
        /// SNMP OID.
        /// </summary>
        public string snmp_oid { get; set; }

        /// <summary>
        /// SNMPv3 auth passphrase. Used only by SNMPv3 item prototypes.
        /// </summary>
        public string snmpv3_authpassphrase { get; set; }

        /// <summary>
        /// SNMPv3 authentication protocol. Used only by SNMPv3 items. 
        /// 
        /// Possible values: 
        /// 0 - (default) MD5; 
        /// 1 - SHA.
        /// </summary>
        public SNMPv3AuthenticationProtocol snmpv3_authprotocol { get; set; }

        /// <summary>
        /// SNMPv3 context name. Used only by SNMPv3 item prototypes.
        /// </summary>
        public string snmpv3_contextname { get; set; }

        /// <summary>
        /// SNMPv3 priv passphrase. Used only by SNMPv3 item prototypes.
        /// </summary>
        public string snmpv3_privpassphrase { get; set; }

        /// <summary>
        /// SNMPv3 privacy protocol. Used only by SNMPv3 items. 
        /// 
        /// Possible values: 
        /// 0 - (default) DES; 
        /// 1 - AES.
        /// </summary>
        public SNMPv3PrivacyProtocol snmpv3_privprotocol { get; set; }

        /// <summary>
        /// SNMPv3 security level. Used only by SNMPv3 item prototypes. 
        /// 
        /// Possible values: 
        /// 0 - noAuthNoPriv; 
        /// 1 - authNoPriv; 
        /// 2 - authPriv.
        /// </summary>
        public SNMPv3SecurityLevel snmpv3_securitylevel { get; set; }

        /// <summary>
        /// SNMPv3 security name. Used only by SNMPv3 item prototypes.
        /// </summary>
        public string snmpv3_securityname { get; set; }

        /// <summary>
        /// HTTP agent item field. Public SSL Key file path.
        /// </summary>
        public string ssl_cert_file { get; set; }

        /// <summary>
        /// HTTP agent item field. Private SSL Key file path.
        /// </summary>
        public string ssl_key_file { get; set; }

        /// <summary>
        /// HTTP agent item field. Password for SSL Key file.
        /// </summary>
        public string ssl_key_password { get; set; }

        /// <summary>
        /// Status of the item prototype. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled item prototype; 
        /// 1 - disabled item prototype; 
        /// 3 - unsupported item prototype.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// HTTP agent item field. Ranges of required HTTP status codes separated by commas. Also supports user macros as part of comma separated list. 
        /// 
        /// Example: 200,200-{$M},{$M},200-400
        /// </summary>
        public string status_codes { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template item prototype.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// HTTP agent item field. Item data polling request timeout. Support user macros. 
        /// 
        /// default: 3s
        /// maximum value: 60s
        /// </summary>
        public string timeout { get; set; }

        /// <summary>
        /// Allowed hosts. Used only by trapper item prototypes.
        /// </summary>
        public string trapper_hosts { get; set; }

        /// <summary>
        /// Number of days to keep item prototype's trends data. 
        /// 
        /// Default: 365.
        /// </summary>
        public string trends { get; set; }

        /// <summary>
        /// Value units.
        /// </summary>
        public string units { get; set; }

        /// <summary>
        /// Username for authentication. Used by simple check, SSH, Telnet, database monitor and JMX item prototypes. 
        /// 
        /// Required by SSH and Telnet item prototypes.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// ID of the associated value map.
        /// </summary>
        public string valuemapid { get; set; }

        /// <summary>
        /// HTTP agent item field. Validate host name in URL is in Common Name field or a Subject Alternate Name field of host certificate.
        /// 
        /// 0 - (default) Do not validate.
        /// 1 - Validate.
        /// </summary>
        public Verify verify_host { get; set; }

        /// <summary>
        /// HTTP agent item field. Validate is host certificate authentic.
        /// 
        /// 0 - (default) Do not validate.
        /// 1 - Validate
        /// </summary>
        public Verify verify_peer { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Applications that the item prototype belongs to
        /// </summary>
        public IList<Application> applications { get; set; }

        /// <summary>
        /// Low-level discovery rule that the graph prototype belongs to
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<DiscoveryRule>))]
        public DiscoveryRule discoveryRule { get; set; }

        /// <summary>
        /// Graph prototypes that the item prototype is used
        /// </summary>
        public IList<Graph> graphs { get; set; }

        /// <summary>
        /// Host that the item prototype belongs to as an array
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Trigger prototypes that the item prototype is used
        /// </summary>
        public IList<Trigger> triggers { get; set; }

        #endregion

        #region ENUMS
        public enum ItemPrototypeType
        {
            ZabbixAgent = 0,
            SNMPv1Agent = 1,
            ZabbixTrapper = 2,
            SimpleCheck = 3,
            SNMPv2Agent = 4,
            ZabbixInternal = 5,
            SNMPv3Agent = 6,
            ZabbixAgentActive = 7,
            ZabbixAggregate = 8,
            ExternalCheck = 10,
            DatabaseMonitor = 11,
            IPMIAgent = 12,
            SSHAgent = 13,
            TELNETAgent = 14,
            Calculated = 15,
            JMXAgent = 16,
            SNMPTrap = 17,
            DependentItem = 18,
            HTTPAgent = 19,
        }

        public enum ValueType
        {
            NumericFloat = 0,
            Character = 1,
            Log = 2,
            NumericUnsigned = 3,
            Text = 4
        }

        public enum DataType
        {
            Decimal = 0,
            Octal = 1,
            Hexadecimal = 2,
            Boolean = 3
        }

        public enum SNMPv3AuthenticationProtocol
        {
            MD5 = 0,
            SHA = 1
        }

        public enum SNMPv3PrivacyProtocol
        {
            DES = 0,
            AES = 1
        }

        public enum SNMPv3SecurityLevel
        {
            NoAuthNoPriv = 0,
            AuthNoPriv = 1,
            AuthPriv = 2
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1,
            Unsupported = 3
        }
        #endregion

        #region Constructors

        public ItemPrototype()
        {
            authtype = AuthenticationMethod.Password;
            follow_redirects = FollowRedirects.FollowRedirects;
            history = "90d";
            snmpv3_authprotocol = SNMPv3AuthenticationProtocol.MD5;
            snmpv3_privprotocol = SNMPv3PrivacyProtocol.DES;
            status = Status.Enabled;
            timeout = "3s";
            trends = "365d";
        }

        #endregion

        #region ShouldSerialize

        public bool ShouldSerializeerror() => false;

        public bool ShouldSerializeflags() => false;

        #endregion
    }
}