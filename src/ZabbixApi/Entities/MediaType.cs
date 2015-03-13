using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class MediaType
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the media type.
        /// </summary>
        public string mediatypeid { get; set; }

        /// <summary>
        /// Name of the media type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Transport used by the media type. 
        /// 
        /// Possible values: 
        /// 0 - email; 
        /// 1 - script; 
        /// 2 - SMS; 
        /// 3 - Jabber; 
        /// 100 - Ez Texting.
        /// </summary>
        public MediaTypeTransport type { get; set; }

        /// <summary>
        /// For script media types exec_path contains the name of the executed script. 
        /// 
        /// For Ez Texting exec_path contains the message text limit. 
        /// Possible text limit values: 
        /// 0 - USA (160 characters); 
        /// 1 - Canada (136 characters). 
        /// 
        /// Required for script and Ez Texting media types.
        /// </summary>
        public string exec_path { get; set; }

        /// <summary>
        /// Serial device name of the GSM modem. 
        /// 
        /// Required for SMS media types.
        /// </summary>
        public string gsm_modem { get; set; }

        /// <summary>
        /// Authentication password. 
        /// 
        /// Required for Jabber and Ez Texting media types.
        /// </summary>
        public string passwd { get; set; }

        /// <summary>
        /// Email address from which notifications will be sent. 
        /// 
        /// Required for email media types.
        /// </summary>
        public string smtp_email { get; set; }

        /// <summary>
        /// SMTP HELO. 
        /// 
        /// Required for email media types.
        /// </summary>
        public string smtp_helo { get; set; }

        /// <summary>
        /// SMTP server. 
        /// 
        /// Required for email media types.
        /// </summary>
        public string smtp_server { get; set; }

        /// <summary>
        /// Whether the media type is enabled. 
        /// 
        /// Possible values: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// Username or Jabber identifier. 
        /// 
        /// Required for Jabber and Ez Texting media types.
        /// </summary>
        public string username { get; set; }

        #endregion

        #region ENUMS

        public enum MediaTypeTransport
        {
            Email = 0,
            Script = 1,
            SMS = 2,
            Jabber = 3,
            EzTexting = 100
        }

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        #endregion

        #region Constructors

        public MediaType()
        {
            status = Status.Enabled;
        }

        #endregion

    }
}
