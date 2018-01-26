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
    public interface IMediaService
    {
        IEnumerable<Media> Get(object filter = null, IEnumerable<MediaInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class MediaService : ServiceBase<Media, MediaInclude>, IMediaService
    {
        public MediaService(IContext context) : base(context, "usermedia") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<MediaInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }
    }

    public enum MediaInclude
    {
        All = 1,
        None = 2
    }
}
