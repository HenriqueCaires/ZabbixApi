using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Entities
{
    public partial class ItemPrototype : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the item prototype.
        /// </summary>
        [JsonProperty("itemid")]
        public override string Id { get; set; }

        /// <summary>
        /// Update interval of the item prototype in seconds.
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// ID of the host that the item prototype belongs to.
        /// </summary>
        public string hostid { get; set; }

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
        /// SSH authentication method. Used only by SSH agent item prototypes. 
        /// 
        /// Possible values: 
        /// 0 - (default) password; 
        /// 1 - public key.
        /// </summary>
        public SSHAuthenticationMethod authtype { get; set; }

        /// <summary>
        /// Data type of the item prototype. 
        /// 
        /// Possible values: 
        /// 0 - (default) decimal; 
        /// 1 - octal; 
        /// 2 - hexadecimal; 
        /// 3 - boolean.
        /// </summary>
        public DataType data_type { get; set; }

        /// <summary>
        /// Flexible intervals as a serialized string. 
        /// 
        /// Each serialized flexible interval consists of an update interval and a time period separated by a forward slash. Multiple intervals are separated by a colon.
        /// </summary>
        public string delay_flex { get; set; }

        /// <summary>
        /// Value that will be stored. 
        /// 
        /// Possible values: 
        /// 0 - (default) as is; 
        /// 1 - Delta, speed per second; 
        /// 2 - Delta, simple change.
        /// </summary>
        public Delta delta { get; set; }

        /// <summary>
        /// Description of the item prototype.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Custom multiplier. 
        /// 
        /// Default: 1.
        /// </summary>
        public float formula { get; set; }

        /// <summary>
        /// Number of days to keep item prototype's history data. 
        /// 
        /// Default: 90.
        /// </summary>
        public int history { get; set; }

        /// <summary>
        /// IPMI sensor. Used only by IPMI item prototypes.
        /// </summary>
        public string ipmi_sensor { get; set; }

        /// <summary>
        /// Format of the time in log entries. Used only by log item prototypes.
        /// </summary>
        public string logtimefmt { get; set; }

        /// <summary>
        /// Whether to use a custom multiplier.
        /// </summary>
        public int multiplier { get; set; }

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
        /// Name of the private key file.
        /// </summary>
        public string privatekey { get; set; }

        /// <summary>
        /// Name of the public key file.
        /// </summary>
        public string publickey { get; set; }

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
        /// 0 - (default) MD5; 
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
        /// 0 - (default) DES; 
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
        /// Status of the item prototype. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled item prototype; 
        /// 1 - disabled item prototype; 
        /// 3 - unsupported item prototype.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template item prototype.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Allowed hosts. Used only by trapper item prototypes.
        /// </summary>
        public string trapper_hosts { get; set; }

        /// <summary>
        /// Number of days to keep item prototype's trends data. 
        /// 
        /// Default: 365.
        /// </summary>
        public int trends { get; set; }

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
        #endregion

        #region Associations

        /// <summary>
        /// Applications that the item prototype belongs to
        /// </summary>
        public IList<Application> applications { get; set; }

        /// <summary>
        /// Low-level discovery rule that the graph prototype belongs to
        /// </summary>
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
            SNMPTrap = 17
        }

        public enum ValueType
        {
            NumericFloat = 0,
            Character = 1,
            Log = 2,
            NumericUnsigned = 3,
            Text = 4
        }

        public enum SSHAuthenticationMethod
        {
            Password = 0,
            PublicKey = 1
        }

        public enum DataType
        {
            Decimal = 0,
            Octal = 1,
            Hexadecimal = 2,
            Boolean = 3
        }

        public enum Delta
        {
            AsIs = 0,
            DeltaSpeedPerSecond = 1,
            DeltaSimpleChange = 2
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
            authtype = SSHAuthenticationMethod.Password;
            data_type = DataType.Decimal;
            delta = Delta.AsIs;
            formula = 1;
            history = 90;
            snmpv3_authprotocol = SNMPv3AuthenticationProtocol.MD5;
            snmpv3_privprotocol = SNMPv3PrivacyProtocol.DES;
            status = Status.Enabled;
            trends = 365;
        }

        #endregion
    }
}
