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
        IList<Media> Get(object filter = null, IList<MediaInclude> include = null);
    }

    public class MediaService : ServiceBase<Media>, IMediaService
    {
        public MediaService(IContext context) : base(context, "usermedia") { }

        public IList<Media> Get(object filter = null, IList<MediaInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",

                filter = filter
            };
            return BaseGet(@params);
        }
    }

    public enum MediaInclude
    {
        All = 1,
        None = 2
    }
}
