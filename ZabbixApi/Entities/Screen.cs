using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public partial class Screen : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the screen.
        /// </summary>
        [JsonProperty("screenid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the screen.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Width of the screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int hsize { get; set; }

        /// <summary>
        /// Height of the screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int vsize { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// The screen items that are used
        /// </summary>
        public IList<ScreenItem> screenitems { get; set; }

        #endregion

        #region Constructors

        public Screen()
        {
            hsize = 1;
            vsize = 1;
        }

        #endregion
    }
}
