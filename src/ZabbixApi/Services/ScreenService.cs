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
    public interface IScreenService : ICRUDService<Screen, ScreenInclude>
    {

    }

    public class ScreenService : CRUDService<Screen, ScreenService.ScreensidsResult, ScreenInclude>, IScreenService
    {
        public ScreenService(IContext context) : base(context, "screen") { }

        public override IEnumerable<Screen> Get(object filter = null, IEnumerable<ScreenInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectScreenItems", includeHelper.WhatShouldInclude(ScreenInclude.ScreenItems));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class ScreensidsResult : EntityResultBase
        {
            [JsonProperty("screenids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ScreenInclude
    {
        All = 1,
        None = 2,
        ScreenItems = 4
    }
}
