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

        public override IEnumerable<UserGroup> Get(object filter = null, IEnumerable<UserGroupInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectUsers = includeHelper.WhatShouldInclude(UserGroupInclude.Users),

                filter = filter
            };
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
