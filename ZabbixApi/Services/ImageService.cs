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
    public interface IImageService : ICRUDService<Image, ImageInclude>
    {

    }

    public class ImageService : CRUDService<Image, ImageService.ImagesidsResult, ImageInclude>, IImageService
    {
        public ImageService(IContext context) : base(context, "image") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ImageInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class ImagesidsResult : EntityResultBase
        {
            [JsonProperty("imageids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ImageInclude
    {
        All = 1,
        None = 2
    }
}
