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
    public partial class Graph : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the graph.
        /// </summary>
        public string graphid { get; set; }


        /// <summary>
        /// Height of the graph in pixels.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Name of the graph
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Width of the graph in pixels.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// (readonly) Origin of the graph. 
        /// 
        /// Possible values are: 
        /// 0 - (default) a plain graph; 
        /// 4 - a discovered graph.
        /// </summary>
        public Flags flags { get; set; }

        /// <summary>
        /// Graph's layout type. 
        /// 
        /// Possible values: 
        /// 0 - (default) normal; 
        /// 1 - stacked; 
        /// 2 - pie; 
        /// 3 - exploded.
        /// </summary>
        public GraphLayoutType graphtype { get; set; }

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
        /// Whether to show pie and exploded graphs in 3D. 
        /// 
        /// Possible values: 
        /// 0 - (default) show in 2D; 
        /// 1 - show in 3D.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_3d { get; set; }

        /// <summary>
        /// Whether to show the legend on the graph. 
        /// 
        /// Possible values: 
        /// 0 - hide; 
        /// 1 - (default) show.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_legend { get; set; }

        /// <summary>
        /// Whether to show the working time on the graph. 
        /// 
        /// Possible values: 
        /// 0 - hide; 
        /// 1 - (default) show.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool show_work_period { get; set; }

        /// <summary>
        /// (readonly) ID of the parent template graph.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// The fixed maximum value for the Y axis.
        /// 
        /// Default: 100.
        /// </summary>
        public float yaxismax { get; set; }

        /// <summary>
        /// The fixed minimum value for the Y axis.
        /// 
        /// Default: 0.
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
        public MaxValueCalculationMethod ymax_type { get; set; }

        /// <summary>
        /// ID of the item that is used as the minimum value for the Y axis.
        /// </summary>
        public string ymin_itemid { get; set; }

        /// <summary>
        /// Minimum value calculation method for the Y axis. 
        /// 
        /// Possible values: 
        /// 0 - (default) calculated; 
        /// </summary>
        public MinValueCalculationMethod ymin_type { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Host Groups
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// Templates
        /// </summary>
        public IList<Template> templates { get; set; }

        /// <summary>
        /// Hosts
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public IList<Item> items { get; set; }

        /// <summary>
        /// Graph Items
        /// </summary>
        public IList<GraphItem> gitems { get; set; }

        /// <summary>
        /// Low-level discovery rule that created the graph
        /// </summary>
        public DiscoveryRule discoveryRule { get; set; }

        #endregion

        #region ENUMS
        public enum Flags
        {
            PlainGraph = 0,
            DiscoveredGraph = 4
        }

        public enum GraphLayoutType
        {
            Normal = 0,
            Stacked = 1,
            Pie = 2,
            Exploded = 3
        }

        public enum MaxValueCalculationMethod
        {
            Calculated = 0,
            Fixed = 1,
            Item = 2
        }

        public enum MinValueCalculationMethod
        {
            Calculated = 0
        }
        #endregion

        #region Constructors

        public Graph()
        {
            flags = Flags.PlainGraph;
            graphtype = GraphLayoutType.Normal;
            percent_left = 0;
            percent_right = 0;
            show_3d = false;
            show_legend = true;
            show_work_period = true;
            yaxismax = 100;
            yaxismin = 0;
            ymax_type = MaxValueCalculationMethod.Calculated;
            ymin_type = MinValueCalculationMethod.Calculated;
        }

        #endregion
    }
}
