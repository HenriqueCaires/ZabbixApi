using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public class ITService
    {
        #region Properties
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

        #region ENUMS
        
        public enum Algorithm
        {
            DoNotCalculate = 0,
            ProblemIfAtLeastOneChildHasAProblem = 1,
            ProblemIfAllChildrenHaveProblems = 2
        }

        #endregion
    }
}
