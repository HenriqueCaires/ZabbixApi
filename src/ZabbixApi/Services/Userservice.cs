using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IUserService : ICRUDService<User, UserInclude>
    {

    }

    public class UserService : CRUDService<User, UserService.UsersidsResult, UserInclude>, IUserService
    {
        public UserService(IContext context) : base(context, "user") { }

        public override IEnumerable<User> Get(object filter = null, IEnumerable<UserInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                getAccess = includeHelper.WhatShouldInclude(UserInclude.Access) != null,
                selectMedias = includeHelper.WhatShouldInclude(UserInclude.Medias),
                selectMediatypes = includeHelper.WhatShouldInclude(UserInclude.MediaTypes),
                selectUsrgrps = includeHelper.WhatShouldInclude(UserInclude.UserGroups),

                filter = filter
            };
            return BaseGet(@params);
        }

        public class UsersidsResult : EntityResultBase
        {
            [JsonProperty("userids")]
            public override string[] ids { get; set; }
        }
    }

    public enum UserInclude
    {
        All = 1,
        None = 2,
        Access = 4,
        Medias = 8,
        MediaTypes = 16,
        UserGroups = 32
    }
}
