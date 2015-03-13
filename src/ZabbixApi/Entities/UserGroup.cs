using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace SisMon.Zabbix.Entities
{
    public partial class UserGroup
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the user group.
        /// </summary>
        public string usrgrpid { get; set; }

        /// <summary>
        /// Name of the user group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Whether debug mode is enabled or disabled. 
        /// 
        /// Possible values are: 
        /// 0 - (default) disabled; 
        /// 1 - enabled.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool debug_mode { get; set; }

        /// <summary>
        /// Frontend authentication method of the users in the group. 
        /// 
        /// Possible values: 
        /// 0 - (default) use the system default authentication method; 
        /// 1 - use internal authentication; 
        /// 2 - disable access to the frontend.
        /// </summary>
        public FrontendAuthenticationMethod gui_access { get; set; }

        /// <summary>
        /// Whether the user group is enabled or disabled. 
        /// 
        /// Possible values are: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status users_status { get; set; }

        #endregion

        #region ENUMS

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        public enum FrontendAuthenticationMethod
        {
            SystemDefaultAuthenticationMethod = 0,
            InternalAuthentication = 1,
            DisableAccess= 2
        }

        #endregion

        #region Constructors

        public UserGroup()
        {
            debug_mode = false;
            gui_access = FrontendAuthenticationMethod.SystemDefaultAuthenticationMethod;
            users_status = Status.Enabled;
        }

        #endregion
    }

    public partial class Permission
    {
        #region Properties

        /// <summary>
        /// ID of the host group to add permission to.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Access level to the host group. 
        /// 
        /// Possible values: 
        /// 0 - access denied; 
        /// 2 - read-only access; 
        /// 3 - read-write access.
        /// </summary>
        public AccessLevel permission { get; set; }

        #endregion

        #region ENUMS

        public enum AccessLevel
        {
            AccessDenied = 0,
            ReadOnly = 2,
            ReadWrite = 3
        }
        #endregion
    }
}
