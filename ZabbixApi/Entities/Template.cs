using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Entities
{
    public partial class Template : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the template.
        /// </summary>
        [JsonProperty("templateid")]
        public override string Id { get; set; }

        /// <summary>
        /// Technical name of the template.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Visible name of the host. 
        /// 
        /// Default: host property value.
        /// </summary>
        public string name { get; set; }

        #endregion

        #region Associations

        /// <summary>
        /// The host groups that the template belongs to
        /// </summary>
        public IList<HostGroup> groups { get; set; }

        /// <summary>
        /// The hosts that are linked to the template
        /// </summary>
        public IList<Host> hosts { get; set; }

        /// <summary>
        /// The child templates
        /// </summary>
        public IList<Template> templates { get; set; }

        /// <summary>
        /// The parent templates
        /// </summary>
        public IList<Template> parentTemplates { get; set; }

        /// <summary>
        /// The web scenarios from the template
        /// </summary>
        public IList<WebScenario> httpSteps { get; set; }
        
        /// <summary>
        /// Items from the template
        /// </summary>
        public IList<Item> items { get; set; }

        //TODO: change object for the right type
        /// <summary>
        /// Low-level discoveries from the template
        /// </summary>
        public IList<object> discoveries { get; set; }

        /// <summary>
        /// Triggers from the template
        /// </summary>
        public IList<Trigger> triggers { get; set; }

        /// <summary>
        /// Graphs from the template
        /// </summary>
        public IList<Graph> graphs { get; set; }

        /// <summary>
        /// Applications from the template
        /// </summary>
        public IList<Application> applications { get; set; }

        //TODO: change object for the right type
        /// <summary>
        /// The macros from the template
        /// </summary>
        public IList<object> macros { get; set; }
        
        /// <summary>
        /// Screens from the template
        /// </summary>
        public IList<Screen> screens { get; set; }

        #endregion
    }
}
