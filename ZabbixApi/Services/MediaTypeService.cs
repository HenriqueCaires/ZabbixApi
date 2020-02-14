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
    public interface IMediaTypeService : ICRUDService<MediaType, MediaTypeInclude>
    {

    }

    public class MediaTypeService : CRUDService<MediaType, MediaTypeService.MediaTypesidsResult, MediaTypeInclude>, IMediaTypeService
    {
        public MediaTypeService(IContext context) : base(context, "mediatype") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<MediaTypeInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectUsers", includeHelper.WhatShouldInclude(MediaTypeInclude.Users));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class MediaTypesidsResult : EntityResultBase
        {
            [JsonProperty("mediatypeids")]
            public override string[] ids { get; set; }
        }
    }

    public enum MediaTypeInclude
    {
        All = 1,
        None = 2,
        Users = 4
    }
}
