using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;
using Zabbix.Helper;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface IImageService : ICRUDService<Image, ImageInclude>
    {

    }

    public class ImageService : CRUDService<Image, ImageService.ImagesidsResult, ImageInclude>, IImageService
    {
        public ImageService(IContext context) : base(context, "image") { }

        public override IList<Image> Get(object filter = null, IList<ImageInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",

                filter = filter
            };
            return BaseGet(@params);
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
