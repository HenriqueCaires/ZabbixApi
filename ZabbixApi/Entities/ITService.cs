using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class ITService : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the IT service.
        /// </summary>
        [JsonProperty("serviceid")]
        public override string Id { get; set; }

        /// <summary>
        /// Algorithm used to calculate the state of the IT service. 
        /// 
        /// Possible values: 
        /// 0 - do not calculate; 
        /// 1 - problem, if at least one child has a problem; 
        /// 2 - problem, if all children have problems.
        /// </summary>
        public Algorithm algorithm { get; set; }

        /// <summary>
        /// Name of the IT service.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Whether SLA should be calculated. 
        /// 
        /// Possible values: 
        /// 0 - do not calculate; 
        /// 1 - calculate.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool showsla { get; set; }

        /// <summary>
        /// Position of the IT service used for sorting.
        /// </summary>
        public int sortorder { get; set; }

        /// <summary>
        /// Minimum acceptable SLA value. If the SLA drops lower, the IT service is considered to be in problem state. 
        /// 
        /// Default: 99.9.
        /// </summary>
        public float goodsla { get; set; }

        /// <summary>
        /// (readonly) Whether the IT service is in OK or problem state. 
        /// 
        /// If the IT service is in problem state, status is equal either to: 
        /// - the priority of the linked trigger if it is set to 2, “Warning” or higher (priorities 0, “Not classified” and 1, “Information” are ignored); 
        /// - the highest status of a child IT service in problem state. 
        /// 
        /// If the IT service is in OK state, status is equal to 0.
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Trigger associated with the IT service. Can only be set for IT services that don't have children.
        /// </summary>
        public string triggerid { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Hard-dependent parent IT service
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<ITService>))]
        public ITService parent { get; set; }

        /// <summary>
        /// Child service dependencies
        /// </summary>
        public IList<ServiceDependency> dependencies { get; set; }

        /// <summary>
        /// Parent service dependencies
        /// </summary>
        public IList<ServiceDependency> parentDependencies { get; set; }

        /// <summary>
        /// Service times
        /// </summary>
        public IList<ServiceTime> times { get; set; }

        /// <summary>
        /// Service alarms
        /// </summary>
        public IList<ServiceAlarm> alarms { get; set; }

        /// <summary>
        /// The associated trigger
        /// </summary>
        [JsonConverter(typeof(SingleObjectConverter<Trigger>))]
        public Trigger trigger { get; set; }
        

        #endregion

        #region ENUMS

        public enum Algorithm
        {
            DoNotCalculate = 0,
            ProblemIfAtLeastOneChildHasAProblem = 1,
            ProblemIfAllChildrenHaveProblems = 2
        }

        #endregion

        #region Constructors

        public ITService()
        {
            goodsla = 99.9f;
        }

        #endregion
    }

    public partial class ServiceTime : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the service time.
        /// </summary>
        [JsonProperty("timeid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the IT service. 
        /// 
        /// Cannot be updated.
        /// </summary>
        public string serviceid { get; set; }

        /// <summary>
        /// Time when the service time comes into effect. 
        /// 
        /// For onetime downtimes ts_from must be set as a Unix timestamp, for other types - as a specific time in a week, in seconds, for example, 90000 for Tue, 2:00 AM.
        /// </summary>
        public int ts_from { get; set; }

        /// <summary>
        /// Time when the service time ends. 
        /// 
        /// For onetime uptimes ts_to must be set as a Unix timestamp, for other types - as a specific time in a week, in seconds, for example, 90000 for Tue, 2:00 AM.
        /// </summary>
        public int ts_to { get; set; }

        /// <summary>
        /// Service time type. 
        /// 
        /// Possible values: 
        /// 0 - planned uptime, repeated every week; 
        /// 1 - planned downtime, repeated every week; 
        /// 2 - one-time downtime.
        /// </summary>
        public ServiceTimeType type { get; set; }

        /// <summary>
        /// Additional information about the service time.
        /// </summary>
        public string note { get; set; }

        #endregion

        #region ENUMS

        public enum ServiceTimeType
        {
            PlannedUptime = 0,
            OlannedDowntime = 1,
            OneTime = 2
        }

        #endregion
    }

    public partial class ServiceDependency : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the service dependency.
        /// </summary>
        [JsonProperty("linkid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the IT service, that a service depends on, that is, the child service. An IT service can have multiple children.
        /// </summary>
        public string servicedownid { get; set; }

        /// <summary>
        /// ID of the IT service, that is dependent on a service, that is, the parent service. An IT service can have multiple parents forming a directed graph.
        /// </summary>
        public string serviceupid { get; set; }

        /// <summary>
        /// Type of dependency between IT services. 
        /// 
        /// Possible values: 
        /// 0 - hard dependency; 
        /// 1 - soft dependency. 
        /// 
        /// An IT service can have only one hard-dependent parent. This attribute has no effect on status or SLA calculation and is only used to create a core IT service tree. Additional parents can be added as soft dependencies forming a graph. 
        /// 
        /// An IT service can not be deleted if it has hard-dependent children.
        /// </summary>
        public DependencyType soft { get; set; }

        #endregion

        #region ENUMS

        public enum DependencyType
        {
            Hard = 0,
            Soft = 1
        }

        #endregion

    }

    public partial class ServiceAlarm : EntityBase
    {
        #region Properties

        /// <summary>
        /// ID of the service alarm.
        /// </summary>
        [JsonProperty("servicealarmid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the IT service.
        /// </summary>
        public string serviceid { get; set; }

        /// <summary>
        /// Time when the IT service state change has happened.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// Status of the IT service. 
        /// 
        /// Refer the the IT service status property for a list of possible values.
        /// </summary>
        public int value { get; set; }

        #endregion

    }
}
