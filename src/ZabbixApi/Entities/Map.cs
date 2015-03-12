using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public class Map
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map.
        /// </summary>
        public string sysmapid { get; set; }

        /// <summary>
        /// Height of the map in pixels.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Name of the map.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Width of the map in pixels.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// ID of the image used as the background for the map.
        /// </summary>
        public string backgroundid { get; set; }

        /// <summary>
        /// Whether to expand macros in labels when configuring the map. 
        /// 
        /// Possible values: 
        /// 0 - (default) do not expand macros; 
        /// 1 - expand macros.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool expand_macros { get; set; }

        /// <summary>
        /// Whether the the problem trigger will be displayed for elements with a single problem. 
        /// 
        /// Possible values: 
        /// 0 - always display the number of problems; 
        /// 1 - (default) display the problem trigger if there's only one problem.
        /// </summary>
        public ExpandProblem expandproblem { get; set; }

        /// <summary>
        /// Whether to enable grid aligning. 
        /// 
        /// Possible values: 
        /// 0 - disable grid aligning; 
        /// 1 - (default) enable grid aligning.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool grid_align { get; set; }

        /// <summary>
        /// Whether to show the grid on the map. 
        /// 
        /// Possible values: 
        /// 0 - do not show the grid; 
        /// 1 - (default) show the grid.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool grid_show { get; set; }

        /// <summary>
        /// Size of the map grid in pixels. 
        /// 
        /// Supported values: 20, 40, 50, 75 and 100. 
        /// 
        /// Default: 50.
        /// </summary>
        public GridSize grid_size { get; set; }

        /// <summary>
        /// Whether icon highlighting is enabled. 
        /// 
        /// Possible values: 
        /// 0 - highlighting disabled; 
        /// 1 - (default) highlighting enabled.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool highlight { get; set; }

        /// <summary>
        /// ID of the icon map used on the map.
        /// </summary>
        public string iconmapid { get; set; }

        /// <summary>
        /// Whether to enable advanced labels. 
        /// 
        /// Possible values: 
        /// 0 - (default) disable advanced labels; 
        /// 1 - enable advanced labels.
        /// </summary>
        public LabelFormat label_format { get; set; }

        /// <summary>
        /// Location of the map element label. 
        /// 
        /// Possible values: 
        /// 0 - (default) bottom; 
        /// 1 - left; 
        /// 2 - right; 
        /// 3 - top.
        /// </summary>
        public LabelLocation label_location { get; set; }

        /// <summary>
        /// Custom label for host elements. 
        /// 
        /// Required for maps with custom host label type.
        /// </summary>
        public string label_string_host { get; set; }

        /// <summary>
        /// Custom label for host group elements. 
        /// 
        /// Required for maps with custom host group label type.
        /// </summary>
        public string label_string_hostgroup { get; set; }

        /// <summary>
        /// Custom label for image elements. 
        /// 
        /// Required for maps with custom image label type.
        /// </summary>
        public string label_string_image { get; set; }

        /// <summary>
        /// Custom label for map elements. 
        /// 
        /// Required for maps with custom map label type.
        /// </summary>
        public string label_string_map { get; set; }

        /// <summary>
        /// Custom label for trigger elements. 
        /// 
        /// Required for maps with custom trigger label type.
        /// </summary>
        public string label_string_trigger { get; set; }

        /// <summary>
        /// Map element label type. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 1 - IP address; 
        /// 2 - (default) element name; 
        /// 3 - status only; 
        /// 4 - nothing.
        /// </summary>
        public LabelType label_type { get; set; }

        /// <summary>
        /// Label type for host elements. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 1 - IP address; 
        /// 2 - (default) element name; 
        /// 3 - status only; 
        /// 4 - nothing; 
        /// 5 - custom.
        /// </summary>
        public LabelTypeHost label_type_host { get; set; }

        /// <summary>
        /// Label type for host group elements. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 2 - (default) element name; 
        /// 3 - status only; 
        /// 4 - nothing; 
        /// 5 - custom.
        /// </summary>
        public LabelTypeHostGroup label_type_hostgroup { get; set; }

        /// <summary>
        /// Label type for host group elements. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 2 - (default) element name; 
        /// 4 - nothing; 
        /// 5 - custom.
        /// </summary>
        public LabelTypeImage label_type_image { get; set; }

        /// <summary>
        /// Label type for map elements. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 2 - (default) element name; 
        /// 3 - status only; 
        /// 4 - nothing; 
        /// 5 - custom.
        /// </summary>
        public LabelTypeMap label_type_map { get; set; }

        /// <summary>
        /// Label type for trigger elements. 
        /// 
        /// Possible values: 
        /// 0 - label; 
        /// 2 - (default) element name; 
        /// 3 - status only; 
        /// 4 - nothing; 
        /// 5 - custom.
        /// </summary>
        public LabelTypeTrigger label_type_trigger { get; set; }

        /// <summary>
        /// Whether to highlight map elements that have recently changed their status. 
        /// 
        /// Possible values: 
        /// 0 - (default) do not highlight elements; 
        /// 1 - highlight elements.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool markelements { get; set; }

        /// <summary>
        /// Minimum severity of the triggers that will be displayed on the map. 
        /// </summary>
        public int severity_min { get; set; }

        /// <summary>
        /// How problems should be displayed. 
        /// 
        /// Possible values: 
        /// 0 - (default) display the count of all problems; 
        /// 1 - display only the count of unacknowledged problems; 
        /// 2 - display the count of acknowledged and unacknowledged problems separately.
        /// </summary>
        public DisplayProblems show_unack { get; set; }

        #endregion

        #region ENUMS

        public enum ExpandProblem
        {
            AlwaysDisplayTheNumberOfProblems = 0,
            DisplayTheProblemTriggerIfThereIsOnlyOneProblem = 1
        }

        public enum GridSize
        {
            p20 = 20, 
            p40 = 40,
            p50 = 50,
            p75 = 75,
            p100 = 10
        }

        public enum LabelFormat
        {
            DisableAdvancedLabels = 0,
            EnableAdvancedLabels = 1
        }

        public enum LabelLocation
        {
            Bottom = 0,
            Left = 1,
            Right = 2,
            Top = 3
        }

        public enum LabelType
        {
            Label = 0,
            IPAddress = 1,
            ElementName = 2,
            StatusOnly = 3,
            Nothing = 4
        }

        public enum LabelTypeHost
        {
            Label = 0,
            IPAddress = 1,
            ElementName = 2,
            StatusOnly = 3,
            Nothing = 4,
            Custom = 5
        }

        public enum LabelTypeHostGroup
        {
            Label = 0,
            ElementName = 1,
            StatusOnly = 3,
            Nothing = 4,
            Custom = 5
        }

        public enum LabelTypeImage
        {
            Label = 0,
            ElementName = 2,
            Nothing = 4,
            Custom = 5
        }

        public enum LabelTypeMap
        {
            Label = 0,
            ElementName = 2,
            StatusOnly = 3,
            Nothing = 4,
            Custom = 5
        }

        public enum LabelTypeTrigger
        {
            Label = 0,
            ElementName = 2,
            StatusOnly = 3,
            Nothing = 4,
            Custom = 5
        }

        public enum DisplayProblems
        {
            CountOfAllProblems = 0,
            OnlyCountOfUnacknowledgedProblems = 1,
            CountOfAcknowledgedAndUnacknowledgedProblemsSeparately = 2
        }
        #endregion
    }
}
