using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Services;
using System.ComponentModel;

namespace ZabbixApi.Entities
{
    public partial class Host : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the host.
        /// </summary>
        [JsonProperty("hostid")]
        public override string Id { get; set; }

        /// <summary>
        /// Technical name of the host.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// (readonly) Availability of Zabbix agent. 
        /// 
        /// Possible values are:
        /// 0 - (default) unknown;
        /// 1 - available;
        /// 2 - unavailable.
        /// </summary>
        public Available available { get; set; }

        /// <summary>
        /// (readonly) The next polling time of an unavailable Zabbix agent.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime disable_until { get; set; }

        /// <summary>
        /// (readonly) Error text if Zabbix agent is unavailable.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// (readonly) Time when Zabbix agent became unavailable.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime errors_from { get; set; }

        /// <summary>
        /// (readonly) Origin of the host. 
        /// 
        /// Possible values: 
        /// 0 - a plain host; 
        /// 4 - a discovered host.
        /// </summary>
        public Flags flags { get; set; }

        /// <summary>
        /// IPMI authentication algorithm. 
        ///
        /// Possible values are:
        /// -1 - (default) default; 
        /// 0 - none; 
        /// 1 - MD2; 
        /// 2 - MD5 
        /// 4 - straight; 
        /// 5 - OEM; 
        /// 6 - RMCP+.
        /// </summary>
        public AuthenticationAlgorithm ipmi_authtype { get; set; }
        
        /// <summary>
        /// (readonly) Availability of IPMI agent. 
        /// 
        /// Possible values are:
        /// 0 - (default) unknown;
        /// 1 - available;
        /// 2 - unavailable.
        /// </summary>
        public Available ipmi_available { get; set; }

        /// <summary>
        /// (readonly) The next polling time of an unavailable IPMI agent.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime ipmi_disable_until { get; set; }

        /// <summary>
        /// (readonly) Error text if IPMI agent is unavailable.
        /// </summary>
        public string ipmi_error { get; set; }

        /// <summary>
        /// (readonly) Time when IPMI agent became unavailable.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime ipmi_errors_from { get; set; }

        /// <summary>
        /// IPMI password.
        /// </summary>
        public string ipmi_password { get; set; }

        /// <summary>
        /// IPMI privilege level. 
        /// 
        /// Possible values are:
        /// 1 - callback;
        /// 2 - (default) user;
        /// 3 - operator;
        /// 4 - admin;
        /// 5 - OEM.
        /// </summary>
        public PrivilegeLevel ipmi_privilege { get; set; }

        /// <summary>
        /// IPMI username.
        /// </summary>
        public string ipmi_username { get; set; }

        /// <summary>
        /// (readonly) Availability of JMX agent. 
        /// 
        /// Possible values are:
        /// 0 - (default) unknown;
        /// 1 - available;
        /// 2 - unavailable.
        /// </summary>
        public Available jmx_available { get; set; }

        /// <summary>
        /// (readonly) The next polling time of an unavailable JMX agent
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime jmx_disable_until { get; set; }

        /// <summary>
        /// (readonly) Error text if JMX agent is unavailable.
        /// </summary>
        public string jmx_error { get; set; }

        /// <summary>
        /// (readonly) Time when JMX agent became unavailable.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime jmx_errors_from { get; set; }

        /// <summary>
        /// (readonly) Starting time of the effective maintenance.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime maintenance_from { get; set; }

        /// <summary>
        /// (readonly) Effective maintenance status. 
        /// 
        /// Possible values are:
        /// 0 - (default) no maintenance;
        /// 1 - maintenance in effect.
        /// </summary>
        public MaintenanceStatus maintenance_status { get; set; }

        /// <summary>
        /// (readonly) Effective maintenance type. 
        /// 
        /// Possible values are:
        /// 0 - (default) maintenance with data collection;
        /// 1 - maintenance without data collection.
        /// </summary>
        public MaintenanceType maintenance_type { get; set; }

        /// <summary>
        /// (readonly) ID of the maintenance that is currently in effect on the host.
        /// </summary>
        public string maintenanceid { get; set; }

        /// <summary>
        /// Visible name of the host. 
        /// 
        /// Default: host property value.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ID of the proxy that is used to monitor the host.
        /// </summary>
        public string proxy_hostid { get; set; }

        /// <summary>
        /// (readonly) Availability of SNMP agent. 
        /// 
        /// Possible values are:
        /// 0 - (default) unknown;
        /// 1 - available;
        /// 2 - unavailable.
        /// </summary>
        public SNMPAvailability snmp_available { get; set; }

        /// <summary>
        /// (readonly) The next polling time of an unavailable SNMP agent.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime snmp_disable_until { get; set; }

        /// <summary>
        /// (readonly) Error text if SNMP agent is unavailable.
        /// </summary>
        public string snmp_error { get; set; }

        /// <summary>
        /// (readonly) Time when SNMP agent became unavailable.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime snmp_errors_from { get; set; }

        /// <summary>
        /// Status and function of the host. 
        /// 
        /// Possible values are:
        /// 0 - (default) monitored host;
        /// 1 - unmonitored host.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// Host inventory population mode. 
        ///
        /// Possible values are: 
        /// -1 - disabled; 
        /// 0 - (default) manual; 
        /// 1 - automatic.
        /// </summary>
        public InventoryMode inventory_mode { get; set; }

        #endregion

        #region Associations

        private IList<Template> _templates;

        /// <summary>
        /// Host Interfaces
        /// </summary>
        public IList<HostInterface> interfaces { get; set; }

        /// <summary>
        /// Host Groups
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// Templates
        /// </summary>
        public IList<Template> parentTemplates
        {
            get
            {
                return _templates;
            }
            set
            {
                _templates = value;
            }
        }

        /// <summary>
        /// Templates
        /// </summary>
        public IList<Template> templates
        {
            get
            {
                return _templates;
            }
            set
            {
                _templates = value;
            }
        }

        /// <summary>
        /// Triggers
        /// </summary>
        public IList<Trigger> triggers { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public IList<Item> items { get; set; }

        /// <summary>
        /// Graphs
        /// </summary>
        public IList<Graph> graphs { get; set; }

        /// <summary>
        /// Applications
        /// </summary>
        public IList<Application> applications { get; set; }

        /// <summary>
        /// HttpTests
        /// </summary>
        public IList<WebScenario> httptests { get; set; }

        /// <summary>
        /// Discovered Services
        /// </summary>
        public IList<DiscoveredService> dservices { get; set; }

        /// <summary>
        /// Maintenances
        /// </summary>
        public IList<Maintenance> maintenances { get; set; }

        /// <summary>
        /// (readonly) Inventory of host. 
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<HostInventory>))]
        public HostInventory inventory { get; set; }

        
        public IList<Tag> tags { get; set; }

        public IList<HostMacro> macros { get; set; }

        #endregion

        #region ENUMS
        public enum Available
        {
            Unknown = 0,
            Available = 1,
            Unavailable = 2
        }

        public enum Status
        {
            Monitored = 0,
            Unmonitored = 1
        }

        public enum Flags
        {
            PlainHost = 0,
            DiscoveredHost = 4
        }

        public enum SNMPAvailability
        {
            Unknown = 0,
            Available = 1,
            Unavailable = 2
        }

        public enum MaintenanceType
        {
            MaintenanceWithDataCollection = 0,
            MaintenanceWithoutDataCollection = 1
        }

        public enum MaintenanceStatus
        {
            NoMaintenance = 0,
            MaintenanceInEffect = 1
        }

        public enum PrivilegeLevel
        {
            Callback = 1,
            User = 2,
            Operator = 3,
            Admin = 4,
            OEM = 5
        }

        public enum AuthenticationAlgorithm
        {
            Default = -1,
            None = 0,
            MD2 = 1,
            MD5 = 2,
            Straight = 4,
            OEM = 5,
            RMCPPlus = 6
        }

        public enum InventoryMode
        {
            Disabled = -1,
            Manual = 0,
            Automatic = 1,
        }

        #endregion

        #region Constructors

        public Host()
        {
            available = Available.Unknown;
            ipmi_authtype = AuthenticationAlgorithm.Default;
            ipmi_available = Available.Unknown;
            ipmi_privilege = PrivilegeLevel.User;
            jmx_available = Available.Unknown;
            maintenance_status = MaintenanceStatus.NoMaintenance;
            maintenance_type = MaintenanceType.MaintenanceWithDataCollection;
            snmp_available = SNMPAvailability.Unknown;
            status = Status.Monitored;
            inventory_mode = InventoryMode.Disabled;
        }

        #endregion

        #region ShouldSerialize
        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeavailable() => false;

        public bool ShouldSerializeparentTemplates() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializedisable_until() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeerror() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeerrors_from() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeflags() => false;
        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeipmi_available() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeipmi_disable_until() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeipmi_error() => false;

        /// <summary>
        /// As propriedades Readonly não deverá Serializar
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeipmi_errors_from() => false;


        public bool ShouldSerializesnmp_disable_until() => false;
        public bool ShouldSerializesnmp_errors_from() => false;
        public bool ShouldSerializejmx_available() => false; 
        public bool ShouldSerializejmx_disable_until() => false;
        public bool ShouldSerializejmx_error() => false;
        public bool ShouldSerializejmx_errors_from() => false;
        public bool ShouldSerializemaintenance_from() => false;
        public bool ShouldSerializemaintenance_status() => false;
        public bool ShouldSerializemaintenance_type() => false;
        public bool ShouldSerializemaintenanceid() => false;
        public bool ShouldSerializesnmp_available() => false;

        #endregion
    }
}
