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
    public interface ITemplateScreenItemService
    {
        IEnumerable<TemplateScreenItem> Get(object filter = null, IEnumerable<TemplateScreenItemInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class TemplateScreenItemService : ServiceBase<TemplateScreenItem>, ITemplateScreenItemService
    {
        public TemplateScreenItemService(IContext context) : base(context, "templatescreenitem") { }

        public IEnumerable<TemplateScreenItem> Get(object filter = null, IEnumerable<TemplateScreenItemInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }
    }

    public enum TemplateScreenItemInclude
    {
        All = 1,
        None = 2
    }
}
