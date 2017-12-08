using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Entities
{
    public class HostInventory
    {

        #region Properties

        /// <summary>
        /// (readonly) ID of the host.
        /// </summary>
        [JsonProperty("hostid")]
        public string Id { get; set; }

        /// <summary>
        /// Alias.
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// Asset tag.
        /// </summary>
        public string asset_tag { get; set; }

        /// <summary>
        /// Chassis.
        /// </summary>
        public string chassis { get; set; }

        /// <summary>
        /// Contact person.
        /// </summary>
        public string contact { get; set; }

        /// <summary>
        /// Contract number.
        /// </summary>
        public string contract_number { get; set; }

        /// <summary>
        /// HW decommissioning date.
        /// </summary>
        public string date_hw_decomm { get; set; }

        /// <summary>
        /// HW maintenance expiry date.
        /// </summary>
        public string date_hw_expiry { get; set; }

        /// <summary>
        /// HW installation date.
        /// </summary>
        public string date_hw_install { get; set; }

        /// <summary>
        /// HW purchase date.
        /// </summary>
        public string date_hw_purchase { get; set; }

        /// <summary>
        /// Deployment status.
        /// </summary>
        public string deployment_status { get; set; }

        /// <summary>
        /// Hardware.
        /// </summary>
        public string hardware { get; set; }

        /// <summary>
        /// Detailed hardware.
        /// </summary>
        public string hardware_full { get; set; }

        /// <summary>
        /// Host subnet mask.
        /// </summary>
        public string host_netmask { get; set; }

        /// <summary>
        /// Host networks.
        /// </summary>
        public string host_networks { get; set; }

        /// <summary>
        /// Host router.
        /// </summary>
        public string host_router { get; set; }
        

        /// <summary>
        /// HW architecture.

        /// </summary>
        public string hw_arch { get; set; }

        /// <summary>
        /// Installer name.
        /// </summary>
        public string installer_name { get; set; }

        /// <summary>
        /// Location.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Location latitude.
        /// </summary>
        public string location_lat { get; set; }

        /// <summary>
        /// Location longitude.
        /// </summary>
        public string location_lon { get; set; }

        /// <summary>
        /// MAC address A.
        /// </summary>
        public string macaddress_a { get; set; }

        /// <summary>
        /// MAC address B.
        /// </summary>
        public string macaddress_b { get; set; }

        /// <summary>
        /// Model.
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string notes { get; set; }

        /// <summary>
        /// OOB IP address.
        /// </summary>
        public string oob_ip { get; set; }

        /// <summary>
        /// OOB host subnet mask.
        /// </summary>
        public string oob_netmask { get; set; }

        /// <summary>
        /// OOB router.
        /// </summary>
        public string oob_router { get; set; }

        /// <summary>
        /// OS name.
        /// </summary>
        public string os { get; set; }

        /// <summary>
        /// Detailed OS name.
        /// </summary>
        public string os_full { get; set; }

        /// <summary>
        /// Short OS name.
        /// </summary>
        public string os_short { get; set; }

        /// <summary>
        /// Primary POC mobile number.
        /// </summary>
        public string poc_1_cell { get; set; }

        /// <summary>
        /// Primary email.
        /// </summary>
        public string poc_1_email { get; set; }

        /// <summary>
        /// Primary POC name.
        /// </summary>
        public string poc_1_name { get; set; }

        /// <summary>
        /// Primary POC notes.
        /// </summary>
        public string poc_1_notes { get; set; }

        /// <summary>
        /// Primary POC phone A.
        /// </summary>
        public string poc_1_phone_a { get; set; }

        /// <summary>
        /// Primary POC phone B.
        /// </summary>
        public string poc_1_phone_b { get; set; }

        /// <summary>
        /// Primary POC screen name.
        /// </summary>
        public string poc_1_screen { get; set; }

        /// <summary>
        /// Secondary POC mobile number.
        /// </summary>
        public string poc_2_cell { get; set; }

        /// <summary>
        /// Secondary POC email.
        /// </summary>
        public string poc_2_email { get; set; }

        /// <summary>
        /// Secondary POC name.
        /// </summary>
        public string poc_2_name { get; set; }

        /// <summary>
        /// Secondary POC notes.
        /// </summary>
        public string poc_2_notes { get; set; }

        /// <summary>
        /// Secondary POC phone A.
        /// </summary>
        public string poc_2_phone_a { get; set; }

        /// <summary>
        /// Secondary POC phone B.
        /// </summary>
        public string poc_2_phone_b { get; set; }

        /// <summary>
        /// Secondary POC screen name.
        /// </summary>
        public string poc_2_screen { get; set; }

        /// <summary>
        /// Serial number A.
        /// </summary>
        public string serialno_a { get; set; }

        /// <summary>
        /// Serial number B.
        /// </summary>
        public string serialno_b { get; set; }

        /// <summary>
        /// Site address A.
        /// </summary>
        public string site_address_a { get; set; }

        /// <summary>
        /// Site address B.
        /// </summary>
        public string site_address_b { get; set; }

        /// <summary>
        /// Site address C.
        /// </summary>
        public string site_address_c { get; set; }

        /// <summary>
        /// Site city.
        /// </summary>
        public string site_city { get; set; }

        /// <summary>
        /// Site country.
        /// </summary>
        public string site_country { get; set; }

        /// <summary>
        /// Site notes.
        /// </summary>
        public string site_notes { get; set; }

        /// <summary>
        /// Site rack location.
        /// </summary>
        public string site_rack { get; set; }

        /// <summary>
        /// Site state.
        /// </summary>
        public string site_state { get; set; }

        /// <summary>
        /// Site ZIP/postal code.
        /// </summary>
        public string site_zip { get; set; }

        /// <summary>
        /// Software.
        /// </summary>
        public string software { get; set; }

        /// <summary>
        /// Software application A.
        /// </summary>
        public string software_app_a { get; set; }

        /// <summary>
        /// Software application B.
        /// </summary>
        public string software_app_b { get; set; }

        /// <summary>
        /// Software application C.
        /// </summary>
        public string software_app_c { get; set; }

        /// <summary>
        /// Software application D.
        /// </summary>
        public string software_app_d { get; set; }

        /// <summary>
        /// Software application E.
        /// </summary>
        public string software_app_e { get; set; }

        /// <summary>
        /// Software details.
        /// </summary>
        public string software_full { get; set; }

        /// <summary>
        /// Tag.
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Type details.
        /// </summary>
        public string type_full { get; set; }

        /// <summary>
        /// URL A.
        /// </summary>
        public string url_a { get; set; }

        /// <summary>
        /// URL B.
        /// </summary>
        public string url_b { get; set; }

        /// <summary>
        /// URL C.
        /// </summary>
        public string url_c { get; set; }

        /// <summary>
        /// Vendor.
        /// </summary>
        public string vendor { get; set; }

        #endregion Properties
    }
}
