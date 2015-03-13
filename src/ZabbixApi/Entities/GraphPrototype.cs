using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public partial class GraphPrototype
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the graph prototype.
        /// </summary>
        public string graphid { get; set; }

        /// <summary>
        /// Height of the graph prototype in pixels.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Name of the graph prototype.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Width of the graph prototype in pixels.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// Graph prototypes's layout type. 
        /// 
        /// Possible values: 
        /// 0 - (default) normal; 
        /// 1 - stacked; 
        /// 2 - pie; 
        /// 3 - exploded.
        /// </summary>
        public GraphPrototypesLayoutType graphtype { get; set; }

        /// <summary>
        /// Left percentile. 
        /// 
        /// Default: 0.
        /// </summary>
        public float percent_left { get; set; }

        /// <summary>
        /// Right percentile. 
        /// 
        /// Default: 0.
        /// </summary>
        public float percent_right { get; set; }

        /// <summary>
        /// Whether to show discovered pie and exploded graphs in 3D. 
        /// 
        /// Possible values: 
        /// 0 - (default) show in 2D; 
        /// 1 - show in 3D.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_3d { get; set; }

        /// <summary>
        /// Whether to show the legend on the discovered graph. 
        /// 
        /// Possible values: 
        /// 0 - hide; 
        /// 1 - (default) show.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_legend { get; set; }

        /// <summary>
        /// Whether to show the working time on the discovered graph. 
        /// 
        /// Possible values: 
        /// 0 - hide; 
        /// 1 - (default) show.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_work_period { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template graph prototype.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// The fixed maximum value for the Y axis.
        /// </summary>
        public float yaxismax { get; set; }

        /// <summary>
        /// The fixed minimum value for the Y axis.
        /// </summary>
        public float yaxismin { get; set; }

        /// <summary>
        /// ID of the item that is used as the maximum value for the Y axis.
        /// </summary>
        public string ymax_itemid { get; set; }

        /// <summary>
        /// Maximum value calculation method for the Y axis. 
        /// 
        /// Possible values: 
        /// 0 - (default) calculated; 
        /// 1 - fixed; 
        /// 2 - item.
        /// </summary>
        public ValueCalculationMethod ymax_type { get; set; }

        /// <summary>
        /// ID of the item that is used as the minimum value for the Y axis.
        /// </summary>
        public string ymin_itemid { get; set; }

        /// <summary>
        /// Minimum value calculation method for the Y axis. 
        /// 
        /// Possible values: 
        /// 0 - (default) calculated; 
        /// 1 - fixed; 
        /// 2 - item.
        /// </summary>
        public ValueCalculationMethod ymin_type { get; set; }
        #endregion

        #region ENUMS
        public enum GraphPrototypesLayoutType
        {
            Normal = 0,
            Stacked = 1,
            Pie = 2,
            Exploded = 3
        }
        public enum ValueCalculationMethod
        {
            Calculated = 0,
            Fixed = 1,
            Item = 2
        }
        #endregion

        #region Constructors

        public GraphPrototype()
        {
            graphtype = GraphPrototypesLayoutType.Normal;
            percent_left = 0;
            percent_right = 0;
            show_3d = false;
            show_legend = true;
            show_work_period = true;
            ymax_type = ValueCalculationMethod.Calculated;
            ymin_type = ValueCalculationMethod.Calculated;
        }

        #endregion
    }
}
