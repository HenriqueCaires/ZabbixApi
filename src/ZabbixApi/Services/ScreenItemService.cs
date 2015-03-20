using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;
using ZabbixApi;

namespace ZabbixApi.Services
{
    public interface IScreenItemService : ICRUDService<ScreenItem, ScreenItemInclude>
    {

    }

    public class ScreenItemService : CRUDService<ScreenItem, ScreenItemService.ScreenItemsidsResult, ScreenItemInclude>, IScreenItemService
    {
        public ScreenItemService(IContext context) : base(context, "screenitem") { }

        public override IEnumerable<ScreenItem> Get(object filter = null, IEnumerable<ScreenItemInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",

                filter = filter
            };
            return BaseGet(@params);
        }

        public class ScreenItemsidsResult : EntityResultBase
        {
            [JsonProperty("screenitemids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ScreenItemInclude
    {
        All = 1,
        None = 2
    }
}
