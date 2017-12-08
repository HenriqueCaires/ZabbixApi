﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public partial class TemplateScreen : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the template screen.
        /// </summary>
        [JsonProperty("screenid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the template screen.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ID of the template that the screen belongs to.
        /// </summary>
        public string templateid { get; set; }

        /// <summary>
        /// Width of the template screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int hsize { get; set; }

        /// <summary>
        /// Height of the template screen. 
        /// 
        /// Default: 1
        /// </summary>
        public int vsize { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// The screen items that are used in the template screen
        /// </summary>
        public IList<ScreenItem> screenitems { get; set; }

        #endregion

        #region Constructors

        public TemplateScreen()
        {
            hsize = 1;
            vsize = 1;
        }

        #endregion
    }
}
