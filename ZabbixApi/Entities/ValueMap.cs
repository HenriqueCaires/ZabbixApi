using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZabbixApi.Entities
{
    public partial class ValueMap : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the value map.
        /// </summary>
        [JsonProperty("valuemapid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the value map.
        /// </summary>
        public string name { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// Value mappings for current value map
        /// </summary>
        public IList<Mapping> mappings { get; set; }
        
        #endregion
    }

    public class Mapping
    {
        /// <summary>
        /// Original value.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// Value to which the original value is mapped to.
        /// </summary>
        public string newvalue { get; set; }
    }

}
