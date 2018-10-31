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
    public partial class Item : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the item.
        /// </summary>
        [JsonProperty("itemid")]
        public override string Id { get; set; }

        /// <summary>
        /// Update interval of the item in seconds.
        /// </summary>
        public string delay { get; set; }

        /// <summary>
        /// ID of the host that the item belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// ID of the item's host interface. Used only for host items. 
        /// 
        /// Optional for Zabbix agent (active), Zabbix internal, Zabbix trapper, Zabbix aggregate, database monitor and calculated items.
        /// </summary>
        public string interfaceid { get; set; }

        /// <summary>
        /// Item key.
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Type of the item. 
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
        /// 9 - web item; 
        /// 10 - external check; 
        /// 11 - database monitor; 
        /// 12 - IPMI agent; 
        /// 13 - SSH agent; 
        /// 14 - TELNET agent; 
        /// 15 - calculated; 
        /// 16 - JMX agent; 
        /// 17 - SNMP trap.
        /// </summary>
        public ItemType type { get; set; }

        /// <summary>
        /// Type of information of the item. 
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
        /// SSH authentication method. Used only by SSH agent items. 
        /// 
        /// Possible values: 
        /// 0 - (default) password; 
        /// 1 - public key.
        /// </summary>
        public SSHAuthenticationMethod authtype { get; set; }

        /// <summary>
        /// Data type of the item. 
        /// 
        /// Possible values: 
        /// 0 - (default) decimal; 
        /// 1 - octal; 
        /// 2 - hexadecimal; 
        /// 3 - boolean.
        /// </summary>
        public DataType data_type { get; set; }

        /// <summary>
        /// Flexible intervals as a serialized string. 
        /// 
        /// Each serialized flexible interval consists of an update interval and a time period separated by a forward slash. Multiple intervals are separated by a colon.
        /// </summary>
        public string delay_flex { get; set; }

        /// <summary>
        /// Value that will be stored. 
        /// 
        /// Possible values: 
        /// 0 - (default) as is; 
        /// 1 - Delta, speed per second; 
        /// 2 - Delta, simple change.
        /// </summary>
        public Delta delta { get; set; }

        /// <summary>
        /// Description of the item.
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
        /// Custom multiplier. 
        /// 
        /// Default: 1.
        /// </summary>
        public float? formula { get; set; }

        /// <summary>
        /// Number of days to keep item's history data. 
        /// 
        /// Default: 90d.
        /// </summary>
        public string history { get; set; }

        /// <summary>
        /// ID of the host inventory field that is populated by the item. 
        /// 
        /// Refer to the host inventory page for a list of supported host inventory fields and their IDs. 
        /// 
        /// Default: 0.
        /// </summary>
        public int inventory_link { get; set; }

        /// <summary>
        /// IPMI sensor. Used only by IPMI items.
        /// </summary>
        public string ipmi_sensor { get; set; }

        /// <summary>
        /// (readonly) Time when the item was last updated. 
        /// 
        /// This property will only return a value for the period configured in ZBX_HISTORY_PERIOD.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastclock { get; set; }

        /// <summary>
        /// (readonly) Nanoseconds when the item was last updated. 
        /// 
        /// This property will only return a value for the period configured in ZBX_HISTORY_PERIOD.
        /// </summary>
        public int lastns { get; set; }

        /// <summary>
        /// (readonly) Last value of the item. 
        /// 
        /// This property will only return a value for the period configured in ZBX_HISTORY_PERIOD.
        /// </summary>
        public string lastvalue { get; set; }

        /// <summary>
        /// Format of the time in log entries. Used only by log items.
        /// </summary>
        public string logtimefmt { get; set; }

        /// <summary>
        /// Time when the monitored log file was last updated. Used only by log items.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime mtime { get; set; }

        /// <summary>
        /// Whether to use a custom multiplier.
        /// </summary>
        public int multiplier { get; set; }

        /// <summary>
        /// Additional parameters depending on the type of the item: 
        /// - executed script for SSH and Telnet items; 
        /// - SQL query for database monitor items; 
        /// - formula for calculated items.
        /// </summary>
        [JsonProperty("params")]
        public string @params { get; set; }

        /// <summary>
        /// Password for authentication. Used by simple check, SSH, Telnet, database monitor and JMX items.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Port monitored by the item. Used only by SNMP items.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// (readonly) Previous value of the item. 
        /// 
        /// This property will only return a value for the period configured in ZBX_HISTORY_PERIOD.
        /// </summary>
        public string prevvalue { get; set; }

        /// <summary>
        /// Name of the private key file.
        /// </summary>
        public string privatekey { get; set; }

        /// <summary>
        /// Name of the public key file.
        /// </summary>
        public string publickey { get; set; }

        /// <summary>
        /// SNMP community. Used only by SNMPv1 and SNMPv2 items.
        /// </summary>
        public string snmp_community { get; set; }

        /// <summary>
        /// SNMP OID.
        /// </summary>
        public string snmp_oid { get; set; }

        /// <summary>
        /// SNMPv3 auth passphrase. Used only by SNMPv3 items.
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
        /// SNMPv3 context name. Used only by SNMPv3 items.
        /// </summary>
        public string snmpv3_contextname { get; set; }

        /// <summary>
        /// SNMPv3 priv passphrase. Used only by SNMPv3 items.
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
        /// SNMPv3 security level. Used only by SNMPv3 items. 
        /// 
        /// Possible values: 
        /// 0 - noAuthNoPriv; 
        /// 1 - authNoPriv; 
        /// 2 - authPriv.
        /// </summary>
        public SNMPv3SecurityLevel snmpv3_securitylevel { get; set; }

        /// <summary>
        /// SNMPv3 security name. Used only by SNMPv3 items.
        /// </summary>
        public string snmpv3_securityname { get; set; }

        /// <summary>
        /// (readonly) State of the item. 
        /// 
        /// Possible values: 
        /// 0 - (default) normal; 
        /// 1 - not supported.
        /// </summary>
        public State state { get; set; }

        /// <summary>
        /// Status of the item. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled item; 
        /// 1 - disabled item.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template item.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Allowed hosts. Used only by trapper items.
        /// </summary>
        public string trapper_hosts { get; set; }

        /// <summary>
        /// Number of days to keep item's trends data. 
        /// 
        /// Default: 365d.
        /// </summary>
        public string trends { get; set; }

        /// <summary>
        /// Value units.
        /// </summary>
        public string units { get; set; }

        /// <summary>
        /// Username for authentication. Used by simple check, SSH, Telnet, database monitor and JMX items. 
        /// 
        /// Required by SSH and Telnet items.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// ID of the associated value map.
        /// </summary>
        public string valuemapid { get; set; }

        /// <summary>
        /// Master item ID.
        ///Recursion up to 3 dependent items and maximum count of dependent items equal to 999 are allowed.
        ///
        ///Required by Dependent items.
        /// </summary>
        public int master_itemid { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Host that the item belongs to as an array
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Host interface used by the item as an array
        /// </summary>
        public IList<HostInterface> interfaces { get; set; }

        /// <summary>
        /// Triggers that the item is used
        /// </summary>
        public IList<Trigger> triggers { get; set; }

        /// <summary>
        /// Graphs that contain the item
        /// </summary>
        public IList<Graph> graphs { get; set; }

        /// <summary>
        /// Applications that the item belongs to
        /// </summary>
        public IList<Application> applications { get; set; }

        /// <summary>
        ///  LLD rule that created the item
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<DiscoveryRule>))]
        public DiscoveryRule discoveryRule { get; set; }

        /// <summary>
        /// Item discovery object
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<ItemDiscovery>))]
        public ItemDiscovery itemDiscovery { get; set; }

        #endregion

        #region ENUMS
        public enum ItemType
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
            WebItem = 9,
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

        public enum Flags
        {
            PlainItem = 0,
            DiscoveredItem = 4
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

        public enum State
        {
            Normal = 0,
            NotSupported = 1
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }
        #endregion

        #region Constructors

        public Item()
        {
            authtype = SSHAuthenticationMethod.Password;
            data_type = DataType.Decimal;
            delta = Delta.AsIs;
            formula = 1;
            history = "90d";
            inventory_link = 0;
            snmpv3_authprotocol = SNMPv3AuthenticationProtocol.MD5;
            snmpv3_privprotocol = SNMPv3PrivacyProtocol.DES;
            state = State.Normal;
            status = Status.Enabled;
            trends = "365d";
        }

        #endregion

        #region ShouldSerialize

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeerror()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeflags()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializelastclock()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializelastns()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializelastvalue()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeprevvalue()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializestate()
        {
            return false;
        }

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializetemplateid()
        {
            return false;
        }
        #endregion
    }

    public partial class ItemDiscovery : EntityBase
    {
        #region Properties

        /// <summary>
        /// ID of the item discovery
        /// </summary>
        [JsonProperty("itemdiscoveryid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the discovered item
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// ID of the item prototype from which the item has been created
        /// </summary>
        public string parent_itemid { get; set; }

        /// <summary>
        /// key of the item prototype
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// Time when the item was last discovered
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime lastcheck { get; set; }

        /// <summary>
        /// Time when an item that is no longer discovered will be deleted
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime ts_delete { get; set; }

        #endregion
    }
}