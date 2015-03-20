using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public partial class GraphItem : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the graph item.
        /// </summary>
        [JsonProperty("gitemid")]
        public override string Id { get; set; }

        /// <summary>
        /// Graph item's draw color as a hexadecimal color code.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// ID of the item.
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// Value of the item that will be displayed. 
        /// 
        /// Possible values: 
        /// 1 - minimum value; 
        /// 2 - (default) average value; 
        /// 4 - maximum value; 
        /// 7 - all values; 
        /// 9 - last value, used only by pie and exploded graphs.
        /// </summary>
        public CalcFunction calc_fnc { get; set; }

        /// <summary>
        /// Draw style of the graph item. 
        /// 
        /// Possible values: 
        /// 0 - (default) line; 
        /// 1 - filled region; 
        /// 2 - bold line; 
        /// 3 - dot; 
        /// 4 - dashed line; 
        /// 5 - gradient line.
        /// </summary>
        public DrawStyle drawtype { get; set; }

        /// <summary>
        /// ID of the graph that the graph item belongs to.
        /// </summary>
        public string graphid { get; set; }

        /// <summary>
        /// Position of the item in the graph. 
        /// 
        /// Default: 0.
        /// </summary>
        public int sortorder { get; set; }

        /// <summary>
        /// Type of graph item. 
        /// 
        /// Possible values: 
        /// 0 - (default) simple; 
        /// 2 - graph sum, used only by pie and exploded graphs.
        /// </summary>
        public GraphItemType type { get; set; }

        /// <summary>
        /// Side of the graph where the graph item's Y scale will be drawn. 
        /// 
        /// Possible values: 
        /// 0 - (default) left side; 
        /// 1 - right side
        /// </summary>
        public YAxisSide yaxisside { get; set; }

        #endregion

        #region ENUMS
        public enum CalcFunction
        {
            Minimum = 1,
            Average = 2,
            Maximum = 4,
            All = 7,
            Last = 9
        }

        public enum DrawStyle
        {
            Line = 0,
            FilledRegion = 1,
            BoldLine = 2,
            Dot = 3,
            DashedLine = 4,
            GradientLine = 5
        }

        public enum GraphItemType
        {
            Simple = 0,
            Sum = 2
        }

        public enum YAxisSide
        {
            Left = 0,
            Right = 1
        }

        #endregion

        #region Associations

        /// <summary>
        /// Graphs
        /// </summary>
        public IList<Graph> graphs { get; set; }

        #endregion

        #region Constructors

        public GraphItem()
        {
            calc_fnc = CalcFunction.Average;
            drawtype = DrawStyle.Line;
            sortorder = 0;
            type = GraphItemType.Simple;
            yaxisside = YAxisSide.Left;
        }

        #endregion
    }
}
