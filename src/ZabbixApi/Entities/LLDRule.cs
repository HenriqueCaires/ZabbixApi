using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public class LLDRule
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the LLD rule.
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// Update interval of the LLD rule in seconds.
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// ID of the host that the LLD rule belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// ID of the LLD rule's host interface. Used only for host LLD rules. 
        /// 
        /// Optional for Zabbix agent (active), Zabbix internal, Zabbix trapper and database monitor LLD rules.
        /// </summary>
        public string interfaceid { get; set; }

        /// <summary>
        /// LLD rule key.
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// LLD rule key.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Type of the LLD rule. 
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
        /// 10 - external check; 
        /// 11 - database monitor; 
        /// 12 - IPMI agent; 
        /// 13 - SSH agent; 
        /// 14 - TELNET agent; 
        /// 16 - JMX agent.
        /// </summary>
        public LLDRuleType type { get; set; }

        /// <summary>
        /// SSH authentication method. Used only by SSH agent LLD rules. 
        /// 
        /// Possible values: 
        /// 0 - (default) password; 
        /// 1 - public key.
        /// </summary>
        public SSHAuthenticationMethod authtype { get; set; }

        /// <summary>
        /// Flexible intervals as a serialized string. 
        /// 
        /// Each serialized flexible interval consists of an update interval and a time period separated by a forward slash. Multiple intervals are separated by a colon.
        /// </summary>
        public string delay_flex { get; set; }

        /// <summary>
        /// Description of the LLD rule.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// (readonly) Error text if there are problems updating the LLD rule.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// LLD rule filter containing the macro to filter by and the regexp to be used for filtering separated by a colon. 
        /// For example {#IFNAME}:@Network interfaces for discovery.
        /// </summary>
        public string filter { get; set; }

        /// <summary>
        /// IPMI sensor. Used only by IPMI LLD rules.
        /// </summary>
        public string ipmi_sensor { get; set; }

        /// <summary>
        /// Time period after which items that are no longer discovered will be deleted, in days. 
        /// 
        /// Default: 30.
        /// </summary>
        public int lifetime { get; set; }

        /// <summary>
        /// Additional parameters depending on the type of the LLD rule: 
        /// - executed script for SSH and Telnet LLD rules; 
        /// - SQL query for database monitor LLD rules; 
        /// - formula for calculated LLD rules.
        /// </summary>
        [JsonProperty("params")]
        public string @params { get; set; }

        /// <summary>
        /// Password for authentication. Used by simple check, SSH, Telnet, database monitor and JMX LLD rules.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Port used by the LLD rule. Used only by SNMP LLD rules.
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
        /// Required for SNMPv1 and SNMPv2 LLD rules.
        /// </summary>
        public string snmp_community { get; set; }

        /// <summary>
        /// SNMP OID.
        /// </summary>
        public string snmp_oid { get; set; }

        /// <summary>
        /// SNMPv3 auth passphrase. Used only by SNMPv3 LLD rules.
        /// </summary>
        public string snmpv3_authpassphrase { get; set; }

        /// <summary>
        /// SNMPv3 authentication protocol. Used only by SNMPv3 LLD rules. 
        /// 
        /// Possible values: 
        /// 0 - (default) MD5; 
        /// 1 - SHA.
        /// </summary>
        public SNMPv3AuthenticationProtocol snmpv3_authprotocol { get; set; }

        /// <summary>
        /// SNMPv3 context name. Used only by SNMPv3 checks.
        /// </summary>
        public string snmpv3_contextname { get; set; }

        /// <summary>
        /// SNMPv3 priv passphrase. Used only by SNMPv3 LLD rules.
        /// </summary>
        public string snmpv3_privpassphrase { get; set; }

        /// <summary>
        /// SNMPv3 privacy protocol. Used only by SNMPv3 LLD rules. 
        /// 
        /// Possible values: 
        /// 0 - (default) DES; 
        /// 1 - AES.
        /// </summary>
        public SNMPv3PrivacyProtocol snmpv3_privprotocol { get; set; }

        /// <summary>
        /// SNMPv3 security level. Used only by SNMPv3 LLD rules. 
        /// 
        /// Possible values: 
        /// 0 - noAuthNoPriv; 
        /// 1 - authNoPriv; 
        /// 2 - authPriv.
        /// </summary>
        public SNMPv3SecurityLevel snmpv3_securitylevel { get; set; }

        /// <summary>
        /// SNMPv3 security name. Used only by SNMPv3 LLD rules.
        /// </summary>
        public string snmpv3_securityname { get; set; }

        /// <summary>
        /// (readonly) State of the LLD rule. 
        /// 
        /// Possible values: 
        /// 0 - (default) normal; 
        /// 1 - not supported.
        /// </summary>
        public State state { get; set; }

        /// <summary>
        /// Status of the LLD rule. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled LLD rule; 
        /// 1 - disabled LLD rule.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template LLD rule.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Allowed hosts. Used only by trapper LLD rules.
        /// </summary>
        public string trapper_hosts { get; set; }

        /// <summary>
        /// Username for authentication. Used by simple check, SSH, Telnet, database monitor and JMX LLD rules. 
        /// 
        /// Required by SSH and Telnet LLD rules.
        /// </summary>
        public string username { get; set; }

        #endregion

        #region ENUMS
        
        public enum LLDRuleType
        {
            ZabbixAgent = 0,
            SNMPv1Agent = 1,
            ZabbixTrapper = 2,
            SimpleCheck = 3,
            SNMPv2Agent = 4,
            ZabbixInternal = 5,
            SNMPv3Agent = 6,
            ZabbixAgentActive = 7,
            ExternalCheck = 10,
            DatabaseMonitor = 11,
            IPMIAgent = 12,
            SSHAgent  = 13,
            TELNETAgent = 14,
            JMXAgent = 16
        }

        public enum SSHAuthenticationMethod
        {
            Password = 0,
            PublicKey = 1
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
    }
}
