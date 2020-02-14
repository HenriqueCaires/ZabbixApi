﻿using Newtonsoft.Json;
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
    public interface ITemplateScreenService : ICRUDService<TemplateScreen, TemplateScreenInclude>
    {

    }

    public class TemplateScreenService : CRUDService<TemplateScreen, TemplateScreenService.TemplateScreensidsResult, TemplateScreenInclude>, ITemplateScreenService
    {
        public TemplateScreenService(IContext context) : base(context, "templatescreen") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TemplateScreenInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectScreenItems", includeHelper.WhatShouldInclude(TemplateScreenInclude.ScreenItems));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class TemplateScreensidsResult : EntityResultBase
        {
            [JsonProperty("screenids")]
            public override string[] ids { get; set; }
        }
    }

    public enum TemplateScreenInclude
    {
        All = 1,
        None = 2,
        ScreenItems = 4
    }
}
