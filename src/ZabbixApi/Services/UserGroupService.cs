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
    public interface IUserGroupService : ICRUDService<UserGroup, UserGroupInclude>
    {

    }

    public class UserGroupService : CRUDService<UserGroup, UserGroupService.UserGroupsidsResult, UserGroupInclude>, IUserGroupService
    {
        public UserGroupService(IContext context) : base(context, "usergroup") { }

        public override IEnumerable<UserGroup> Get(object filter = null, IEnumerable<UserGroupInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectUsers", includeHelper.WhatShouldInclude(UserGroupInclude.Users));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class UserGroupsidsResult : EntityResultBase
        {
            [JsonProperty("usrgrpids")]
            public override string[] ids { get; set; }
        }
    }

    public enum UserGroupInclude
    {
        All = 1,
        None = 2,
        Users = 4
    }
}
