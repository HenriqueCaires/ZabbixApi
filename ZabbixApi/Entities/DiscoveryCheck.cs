using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class DiscoveryCheck : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the discovery check.
        /// </summary>
        [JsonProperty("dcheckid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the discovery rule that the check belongs to.
        /// </summary>
        public string druleid { get; set; }

        /// <summary>
        /// The value of this property differs depending on the type type of the check: 
        /// - key to query for Zabbix agent checks, required; 
        /// - SNMP OID for SNMPv1, SNMPv2 and SNMPv3 checks, required.
        /// </summary>
        public string key_ { get; set; }

        /// <summary>
        /// One or several port ranges to check separated by commas. Used for all checks except for ICMP. 
        /// 
        /// Default: 0.
        /// </summary>
        public string ports { get; set; }

        /// <summary>
        /// SNMP community. 
        /// 
        /// Required for SNMPv1 and SNMPv2 agent checks.
        /// </summary>
        public string snmp_community { get; set; }

        /// <summary>
        /// Auth passphrase used for SNMPv3 agent checks with security level set to authNoPriv or authPriv.
        /// </summary>
        public string snmpv3_authpassphrase { get; set; }

        /// <summary>
        /// Authentication protocol used for SNMPv3 agent checks with security level set to authNoPriv or authPriv. 
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
        /// Priv passphrase used for SNMPv3 agent checks with security level set to authPriv.
        /// </summary>
        public string snmpv3_privpassphrase { get; set; }

        /// <summary>
        /// Privacy protocol used for SNMPv3 agent checks with security level set to authPriv. 
        /// 
        /// Possible values: 
        /// 0 - (default) DES; 
        /// 1 - AES.
        /// </summary>
        public SNMPv3PrivacyProtocol snmpv3_privprotocol { get; set; }

        /// <summary>
        /// Security level used for SNMPv3 agent checks. 
        /// 
        /// Possible values: 
        /// 0 - noAuthNoPriv; 
        /// 1 - authNoPriv; 
        /// 2 - authPriv.
        /// </summary>
        public string snmpv3_securitylevel { get; set; }

        /// <summary>
        /// Security name used for SNMPv3 agent checks.
        /// </summary>
        public string snmpv3_securityname { get; set; }

        /// <summary>
        /// Type of check. 
        /// 
        /// Possible values: 
        /// 0 - (default) SSH; 
        /// 1 - LDAP; 
        /// 2 - SMTP; 
        /// 3 - FTP; 
        /// 4 - HTTP; 
        /// 5 - POP; 
        /// 6 - NNTP; 
        /// 7 - IMAP; 
        /// 8 - TCP; 
        /// 9 - Zabbix agent; 
        /// 10 - SNMPv1 agent; 
        /// 11 - SNMPv2 agent; 
        /// 12 - ICMP ping; 
        /// 13 - SNMPv3 agent; 
        /// 14 - HTTPS; 
        /// 15 - Telnet.
        /// </summary>
        public CheckType type { get; set; }

        /// <summary>
        /// Whether to use this check as a device uniqueness criteria. 
        /// Only a single unique check can be configured for a discovery rule. Used for Zabbix agent, SNMPv1, SNMPv2 and SNMPv3 agent checks. 
        /// 
        /// Possible values: 
        /// 0 - (default) do not use this check as a uniqueness criteria; 
        /// 1 - use this check as a uniqueness criteria.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool uniq { get; set; }
        #endregion

        #region ENUMS
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

        public enum CheckType
        {
            SSH = 0,
            LDAP = 1,
            SMTP = 2,
            FTP = 3,
            HTTP = 4,
            POP = 5,
            NNTP = 6,
            IMAP = 7,
            TCP = 8,
            ZabbixAgent = 9,
            SNMPv1Agent = 10,
            SNMPv2Agent = 11,
            ICMPPing = 12,
            SNMPv3Agent = 13,
            HTTPS = 14,
            Telnet = 15
        }
        #endregion

        #region Constructors

        public DiscoveryCheck()
        {
            ports = "0";
            snmpv3_authprotocol = SNMPv3AuthenticationProtocol.MD5;
            snmpv3_privprotocol = SNMPv3PrivacyProtocol.DES;
            type = CheckType.SSH;
            uniq = false;
        }

        #endregion
    }
}
