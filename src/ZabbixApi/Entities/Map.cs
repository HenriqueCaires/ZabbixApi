using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace Zabbix.Entities
{
    public partial class Map : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map.
        /// </summary>
        public string sysmapid { get; set; }
        [JsonProperty("sysmapid")]
        public override string Id { get; set; }

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

        #region Constructors

        public Map()
        {
            expand_macros = false;
            expandproblem = ExpandProblem.DisplayTheProblemTriggerIfThereIsOnlyOneProblem;
            grid_align = true;
            grid_show = true;
            grid_size = GridSize.p50;
            highlight = true;
            label_format = LabelFormat.DisableAdvancedLabels;
            label_location = LabelLocation.Bottom;
            label_type = LabelType.ElementName;
            label_type_host = LabelTypeHost.ElementName;
            label_type_hostgroup = LabelTypeHostGroup.ElementName;
            label_type_image = LabelTypeImage.ElementName;
            label_type_map = LabelTypeMap.ElementName;
            label_type_trigger = LabelTypeTrigger.ElementName;
            markelements = false;
            show_unack = DisplayProblems.CountOfAllProblems;
        }

        #endregion
    }

    public partial class MapElement : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map element.
        /// </summary>
        [JsonProperty("selementid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the object that the map element represents. 
        /// 
        /// Required for host, host group, trigger and map type elements.
        /// </summary>
        public string elementid { get; set; }

        /// <summary>
        /// Type of map element. 
        /// 
        /// Possible values: 
        /// 0 - host; 
        /// 1 - map; 
        /// 2 - trigger; 
        /// 3 - host group; 
        /// 4 - image.
        /// </summary>
        public MapElementType elementtype { get; set; }

        /// <summary>
        /// ID of the image used to display the element in default state.
        /// </summary>
        public string iconid_off { get; set; }

        /// <summary>
        /// How separate host group hosts should be displayed. 
        /// 
        /// Possible values: 
        /// 0 - (default) the host group element will take up the whole map; 
        /// 1 - the host group element will have a fixed size.
        /// </summary>
        public AreaType areatype { get; set; }

        /// <summary>
        /// How a host group element should be displayed on a map. 
        /// 
        /// Possible values: 
        /// 0 - (default) display the host group as a single element; 
        /// 1 - display each host in the group separately.
        /// </summary>
        public MapElementSubtype elementsubtype { get; set; }

        /// <summary>
        /// Height of the fixed size host group element in pixels. 
        /// 
        /// Default: 200.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// ID of the image used to display disabled map elements. Unused for image elements.
        /// </summary>
        public string iconid_disabled { get; set; }

        /// <summary>
        /// ID of the image used to display map elements in maintenance. Unused for image elements.
        /// </summary>
        public string iconid_maintenance { get; set; }

        /// <summary>
        /// ID of the image used to display map elements with problems. Unused for image elements.
        /// </summary>
        public string iconid_on { get; set; }

        /// <summary>
        /// Label of the element.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// Location of the map element label. 
        /// 
        /// Possible values: 
        /// -1 - (default) default location; 
        /// 0 - bottom; 
        /// 1 - left; 
        /// 2 - right; 
        /// 3 - top.
        /// </summary>
        public LabelLocation label_location { get; set; }

        /// <summary>
        /// (readonly) ID of the map that the element belongs to.
        /// </summary>
        public string sysmapid { get; set; }

        /// <summary>
        /// Map element URLs. 
        /// 
        /// The map element URL object is described in detail below.
        /// </summary>
        public IList<MapElementURL> urls { get; set; }

        /// <summary>
        /// Whether icon mapping must be used for host elements. 
        /// 
        /// Possible values: 
        /// 0 - do not use icon mapping; 
        /// 1 - (default) use icon mapping.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool use_iconmap { get; set; }

        /// <summary>
        /// Host group element placing algorithm. 
        /// 
        /// Possible values: 
        /// 0 - (default) grid.
        /// </summary>
        public ViewType viewtype { get; set; }

        /// <summary>
        /// Width of the fixed size host group element in pixels. 
        /// 
        /// Default: 200.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// X-coordinates of the element in pixels. 
        /// 
        /// Default: 0.
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Y-coordinates of the element in pixels. 
        /// 
        /// Default: 0.
        /// </summary>
        public int y { get; set; }

        #endregion

        #region ENUMS

        public enum MapElementType
        {
            Host = 0,
            Map = 1,
            Trigger = 2,
            HostGroup = 3,
            Image = 4
        }

        public enum AreaType
        {
            TakeUpTheWholeMap = 0,
            HaveAFixedSize = 1
        }

        public enum MapElementSubtype
        {
            DisplayHostGroupAsSingleElement = 0,
            DisplayEachHostInGroupSeparately = 1
        }

        public enum LabelLocation
        {
            DefaultLocation = -1,
            Bottom = 0,
            Left = 1,
            Right = 2,
            Top = 3
        }

        public enum ViewType
        {
            Grid = 0
        }

        #endregion

        #region Constructors

        public MapElement()
        {
            areatype = AreaType.TakeUpTheWholeMap;
            elementsubtype = MapElementSubtype.DisplayHostGroupAsSingleElement;
            height = 200;
            label_location = LabelLocation.DefaultLocation;
            use_iconmap = true;
            viewtype = ViewType.Grid;
            width = 200;
            x = 0;
            y = 0;
        }

        #endregion
    }

    public partial class MapElementURL : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map element URL.
        /// </summary>
        [JsonProperty("sysmapelementurlid")]
        public override string Id { get; set; }

        /// <summary>
        /// Link caption.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Link URL.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// ID of the map element that the URL belongs to.
        /// </summary>
        public string selementid { get; set; }

        #endregion
    }

    public partial class MapLink : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map link.
        /// </summary>
        [JsonProperty("linkid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the first map element linked on one end.
        /// </summary>
        public string selementid1 { get; set; }

        /// <summary>
        /// ID of the first map element linked on the other end.
        /// </summary>
        public string selementid2 { get; set; }

        /// <summary>
        /// Line color as a hexadecimal color code. 
        /// 
        /// Default: 000000.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// Link line draw style. 
        /// 
        /// Possible values: 
        /// 0 - (default) line; 
        /// 2 - bold line; 
        /// 3 - dotted line; 
        /// 4 - dashed line.
        /// </summary>
        public DrawStyle drawtype { get; set; }

        /// <summary>
        /// Link label.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// Map link triggers to use as link status indicators. 
        /// 
        /// The map link trigger object is described in detail below.
        /// </summary>
        public IList<MapLinkTrigger> linktriggers { get; set; }

        /// <summary>
        /// ID of the map the link belongs to.
        /// </summary>
        public string sysmapid { get; set; }

        #endregion

        #region ENUMS

        public enum DrawStyle
        {
            Line = 0,
            BoldLine = 2,
            DottedLine = 3,
            DashedLine = 4
        }

        #endregion

        #region Constructors

        public MapLink()
        {
            color = "000000";
            drawtype = DrawStyle.Line;
        }

        #endregion
    }

    public partial class MapLinkTrigger : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map link trigger.
        /// </summary>
        [JsonProperty("linktriggerid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the trigger used as a link indicator.
        /// </summary>
        public string triggerid { get; set; }

        /// <summary>
        /// Indicator color as a hexadecimal color code. 
        /// 
        /// Default: DD0000.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// Indicator draw style. 
        /// 
        /// Possible values: 
        /// 0 - (default) line; 
        /// 2 - bold line; 
        /// 3 - dotted line; 
        /// 4 - dashed line.
        /// </summary>
        public DrawStyle drawtype { get; set; }

        /// <summary>
        /// ID of the map link that the link trigger belongs to.
        /// </summary>
        public string linkid { get; set; }

        #endregion

        #region ENUMS

        public enum DrawStyle
        {
            Line = 0,
            BoldLine = 2,
            DottedLine = 3,
            DashedLine = 4
        }

        #endregion

        #region Constructors

        public MapLinkTrigger()
        {
            color = "DD0000";
            drawtype = DrawStyle.Line;
        }

        #endregion
    }

    public partial class MapURL : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the map URL.
        /// </summary>
        [JsonProperty("sysmapurlid")]
        public override string Id { get; set; }

        /// <summary>
        /// Link caption.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Link URL.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Type of map element for which the URL will be available. 
        /// 
        /// Refer to the map element "type" property for a list of supported types. 
        /// 
        /// Default: 0.
        /// </summary>
        public int elementtype { get; set; }

        /// <summary>
        /// ID of the map that the URL belongs to.
        /// </summary>
        public string sysmapid { get; set; }

        #endregion

        #region Constructors

        public MapURL()
        {
            elementtype = 0;
        }

        #endregion
    }
}
