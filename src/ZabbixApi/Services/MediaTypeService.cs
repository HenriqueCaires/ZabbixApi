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

        public override IEnumerable<MediaType> Get(object filter = null, IEnumerable<MediaTypeInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectUsers = includeHelper.WhatShouldInclude(MediaTypeInclude.Users),

                filter = filter
            };
            return BaseGet(@params);
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
