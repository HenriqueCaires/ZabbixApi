﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Entities
{
    public partial class Application : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the application.
        /// </summary>
        [JsonProperty("applicationid")]
        public override string Id { get; set; }

        /// <summary>
        /// ID of the host that the application belongs to. 
        /// 
        /// Cannot be updated.
        /// </summary>
        public string hostid { get; set; }

        /// <summary>
        /// Name of the application
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (readonly) IDs of the parent template applications.
        /// </summary>
        public IList<string> templateids { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// Hosts
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public IList<Item> items { get; set; }

        #endregion
    }
}
