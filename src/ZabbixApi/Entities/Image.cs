using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMon.Zabbix.Entities
{
    public partial class Image
    {
        #region Properties

        /// <summary>
        /// (readonly) ID of the image.
        /// </summary>
        public string imageid { get; set; }

        /// <summary>
        /// Name of the image.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Type of image. 
        /// 
        /// Possible values: 
        /// 1 - (default) icon; 
        /// 2 - background image.
        /// </summary>
        public ImageType imagetype { get; set; }

        #endregion

        #region ENUMS
        public enum ImageType
        {
            Icon = 1,
            BackgroundImage = 2
        }
        #endregion

    }
}
