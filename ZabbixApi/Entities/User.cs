using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;

namespace ZabbixApi.Entities
{
    public partial class User : EntityBase
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the user.
        /// </summary>
        [JsonProperty("userid")]
        public override string Id { get; set; }

        /// <summary>
        /// User alias.
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// (readonly) Time of the last unsuccessful login attempt.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime attempt_clock { get; set; }

        /// <summary>
        /// (readonly) Recent failed login attempt count.
        /// </summary>
        public int attempt_failed { get; set; }

        /// <summary>
        /// (readonly) IP address from where the last unsuccessful login attempt came from.
        /// </summary>
        public string attempt_ip { get; set; }

        /// <summary>
        /// Whether to enable auto-login. 
        /// 
        /// Possible values: 
        /// 0 - (default) auto-login disabled; 
        /// 1 - auto-login enabled.
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool autologin { get; set; }

        /// <summary>
        /// User session life time in seconds. If set to 0, the session will never expire. 
        /// 
        /// Default: 900.
        /// </summary>
        public string autologout { get; set; }

        /// <summary>
        /// Language code of the user's language. 
        /// 
        /// Default: en_GB.
        /// </summary>
        public string lang { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Automatic refresh period in seconds. 
        /// 
        /// Default: 30.
        /// </summary>
        public string refresh { get; set; }

        /// <summary>
        /// Amount of object rows to show per page. 
        /// 
        /// Default: 50.
        /// </summary>
        public int rows_per_page { get; set; }

        /// <summary>
        /// Surname of the user.
        /// </summary>
        public string surname { get; set; }

        /// <summary>
        /// User's theme. 
        /// 
        /// Possible values: 
        /// default - (default) system default; 
        /// classic - Classic; 
        /// originalblue - Original blue; 
        /// darkblue - Black & Blue; 
        /// darkorange - Dark orange.
        /// </summary>
        public string theme { get; set; }

        /// <summary>
        /// Type of the user. 
        /// 
        /// Possible values: 
        /// 1 - (default) Zabbix user; 
        /// 2 - Zabbix admin; 
        /// 3 - Zabbix super admin.
        /// </summary>
        public UserType type { get; set; }

        /// <summary>
        /// URL of the page to redirect the user to after logging in.
        /// </summary>
        public string url { get; set; }

        #region Access

        /// <summary>
        /// User's frontend authentication method. Refer to the gui_access property of the user group object for a list of possible values
        /// </summary>
        public Permission.AccessLevel gui_access { get; set; }

        /// <summary>
        /// Indicates whether debug is enabled for the user. Possible values: 0 - debug disabled, 1 - debug enabled
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool debug_mode { get; set; }

        /// <summary>
        /// Indicates whether the user is disabled. Possible values: 0 - user enabled, 1 - user disabled
        /// </summary>
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool users_status { get; set; }

        #endregion

        #endregion

        #region Associations

        /// <summary>
        /// Media used by the user
        /// </summary>
        public IList<Media> medias { get; set; }

        /// <summary>
        /// Media types used by the user
        /// </summary>
        public IList<MediaType> mediatypes { get; set; }

        /// <summary>
        /// User groups that the user belongs to
        /// </summary>
        public IList<UserGroup> usrgrps { get; set; }

        #endregion

        #region ENUMS

        public enum UserType
        {
            ZabbixUser = 1,
            ZabbixAdmin = 2,
            ZabbixSuperAdmin = 3
        }

        #endregion

        #region Constructors

        public User()
        {
            autologin = false;
            autologout = "900";
            lang = "en_GB";
            refresh = "30";
            rows_per_page = 50;
            theme = "default";
            type = UserType.ZabbixUser;
        }

        #endregion
    }
}