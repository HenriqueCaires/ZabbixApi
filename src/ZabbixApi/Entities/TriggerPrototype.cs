using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class TriggerPrototype
    {
        #region Properties
        
        /// <summary>
        /// (readonly) ID of the trigger prototype.
        /// </summary>
        public string triggerid { get; set; }

        /// <summary>
        /// Name of the trigger prototype.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Reduced trigger expression.
        /// </summary>
        public string expression { get; set; }

        /// <summary>
        /// Additional comments to the trigger prototype.
        /// </summary>
        public string comments { get; set; }

        /// <summary>
        /// Severity of the trigger prototype. 
        /// 
        /// Possible values: 
        /// 0 - (default) not classified; 
        /// 1 - information; 
        /// 2 - warning; 
        /// 3 - average; 
        /// 4 - high; 
        /// 5 - disaster.
        /// </summary>
        public Severity priority { get; set; }

        /// <summary>
        /// Whether the trigger prototype is enabled or disabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template trigger prototype.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Whether the trigger prototype can generate multiple problem events. 
        /// 
        /// Possible values: 
        /// 0 - (default) do not generate multiple events; 
        /// 1 - generate multiple events.
        /// </summary>
        public MultipleProblemEvents type { get; set; }

        /// <summary>
        /// URL associated with the trigger prototype.
        /// </summary>
        public string url { get; set; }

        #endregion

        #region ENUMS

        public enum MultipleProblemEvents
        {
            DoNotGenerateMultipleEvents = 0,
            GenerateMultipleEvents = 1
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        public enum Severity
        {
            NotClassified = 0,
            Information = 1,
            Warning = 2,
            Average = 3,
            High = 4,
            Disaster = 5
        }

        #endregion
    }
}
