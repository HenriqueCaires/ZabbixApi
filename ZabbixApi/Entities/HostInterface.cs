using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Entities
{
    public partial class HostInterface : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the interface.
        /// </summary>
        [JsonProperty("interfaceid")]
        public override string Id { get; set; }

        /// <summary>
        /// DNS name used by the interface. 
        /// 
        /// Can be empty if the connection is made via IP.
        /// </summary>
        public string dns { get; set; }

        /// <summary>
        /// ID of the host the interface belongs to.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// IP address used by the interface. 
        /// 
        /// Can be empty if the connection is made via DNS.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Whether the interface is used as default on the host. Only one interface of some type can be set as default on a host. 
        /// 
        /// Possible values are: 
        /// 0 - not default; 
        /// 1 - default.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool main { get; set; }

        /// <summary>
        /// Port number used by the interface. Can contain user macros.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// Interface type. 
        /// 
        /// Possible values are: 
        /// 1 - agent; 
        /// 2 - SNMP; 
        /// 3 - IPMI; 
        /// 4 - JMX. 
        /// </summary>
        public InterfaceType type { get; set; }

        /// <summary>
        /// Whether the connection should be made via IP. 
        /// 
        /// Possible values are: 
        /// 0 - connect using host DNS name; 
        /// 1 - connect using host IP address.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool useip { get; set; }

        #endregion 

        #region Associations

        /// <summary>
        /// Items that use the interface
        /// </summary>
        public IList<Item> items { get; set; }

        public InterfaceDetails details { get; set; }

        /// <summary>
        /// Host that uses the interface as an array
        /// </summary>
        public IList<Host> hosts { get; set; }

        #endregion

        #region ENUMS

        public enum InterfaceType
        {
            Agent = 1,
            SNMP = 2,
            IPMI = 3,
            JMX = 4
        }

        #endregion

        #region ShouldSerialize
        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializedetails() => type == InterfaceType.SNMP;

        #endregion 
    }

    public class InterfaceDetails
    {
        public InterfaceDetails()
        {
            version = SNMPInterfaceVersion.SNMPv2c;
            bulk = true;
            securitylevel = SNMPv3SecurityLevel.noAuthNoPriv;
            authprotocol = SNMPv3AuthProtocol.MD5;
            privprotocol = SNMPv3PrivProtocol.DES;
        }

        public SNMPInterfaceVersion version { get; set; }
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool bulk { get; set; }
        public string community { get; set; }
        public string securityname { get; set; }
        public SNMPv3SecurityLevel securitylevel { get; set; }

        public string authpassphrase { get; set; }
        public string privpassphrase { get; set; }
        public SNMPv3AuthProtocol authprotocol { get; set; }
        public SNMPv3PrivProtocol privprotocol { get; set; }
        public string contextname { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializecommunity() => version != SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializesecurityname() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializesecuritylevel() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializeauthpassphrase() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializeprivpassphrase() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializeauthprotocol() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializeprivprotocol() => version == SNMPInterfaceVersion.SNMPv3;
        public bool ShouldSerializecontextname() => version == SNMPInterfaceVersion.SNMPv3;

        #endregion 

        #region ENUMS

        public enum SNMPInterfaceVersion
        {
            SNMPv1 = 1,
            SNMPv2c = 2,
            SNMPv3 = 3,
        }

        public enum SNMPv3SecurityLevel
        {
            noAuthNoPriv = 0,
            authNoPriv = 1,
            authPriv = 2,
        }

        public enum SNMPv3AuthProtocol
        {
            MD5 = 0,
            SHA = 1,
        }

        public enum SNMPv3PrivProtocol
        {
            DES = 0,
            AES = 1,
        }


        #endregion
    }
}
