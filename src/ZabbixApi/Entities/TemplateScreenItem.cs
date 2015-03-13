using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class TemplateScreenItem
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the template screen item.
        /// </summary>
        public string screenitemid { get; set; }

        /// <summary>
        /// Number of columns the template screen item will span across.
        /// </summary>
        public int colspan { get; set; }

        /// <summary>
        /// ID of the object from the parent template displayed on the template screen item. Depending on the type of screen item, the resourceid property can reference different objects. Unused by clock and URL template screen items. 
        /// 
        /// Note: the resourceid property always references an object used in the parent template object, even if the screen item itself is inherited on a host or template.
        /// </summary>
        public string resourceid { get; set; }

        /// <summary>
        /// Type of template screen item. 
        /// 
        /// Possible values: 
        /// 0 - graph; 
        /// 1 - simple graph; 
        /// 3 - plain text; 
        /// 7 - clock; 
        /// 11 - URL.
        /// </summary>
        public TemplateScreenItemType resourcetype { get; set; }

        /// <summary>
        /// Number or rows the template screen item will span across.
        /// </summary>
        public int rowspan { get; set; }

        /// <summary>
        /// ID of the template screen that the item belongs to.
        /// </summary>
        public string screenid { get; set; }

        /// <summary>
        /// Number of lines to display on the template screen item. 
        /// 
        /// Default: 25.
        /// </summary>
        public int elements { get; set; }

        /// <summary>
        /// Specifies how the template screen item must be aligned horizontally in the cell. 
        /// 
        /// Possible values: 
        /// 0 - (default) center; 
        /// 1 - left; 
        /// 2 - right.
        /// </summary>
        public HAlign halign { get; set; }

        /// <summary>
        /// Height of the template screen item in pixels. 
        /// 
        /// Default: 200.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Template screen item display option. 
        /// 
        /// Possible values for clock screen items: 
        /// 0 - (default) local time; 
        /// 1 - server time; 
        /// 2 - host time. 
        /// 
        /// Possible values for plain text screen items: 
        /// 0 - (default) display values as plain text; 
        /// 1 - display values as HTML.
        /// </summary>
        public int style { get; set; }

        /// <summary>
        /// URL of the webpage to be displayed in the template screen item. Used by URL template screen items.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Specifies how the template screen item must be aligned vertically in the cell. 
        /// 
        /// Possible values: 
        /// 0 - (default) middle; 
        /// 1 - top; 
        /// 2 - bottom.
        /// </summary>
        public VAlign valign { get; set; }

        /// <summary>
        /// Width of the template screen item in pixels. 
        /// 
        /// Default: 320.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// X-coordinates of the template screen item on the screen, from left to right. 
        /// 
        /// Default: 0.
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Y-coordinates of the template screen item on the screen, from top to bottom. 
        /// 
        /// Default: 0.
        /// </summary>
        public int y { get; set; }

        #endregion

        #region ENUMS

        public enum TemplateScreenItemType
        {
            Graph = 0,
            SimpleGraph = 1,
            PlainText = 3,
            Clock = 7,
            URL = 11
        }

        public enum HAlign
        {
            Center = 0,
            Left = 1,
            Right = 2
        }

        public enum VAlign
        {
            Middle = 0,
            Top = 1,
            Bottom = 2
        }


        #endregion
    }
}
