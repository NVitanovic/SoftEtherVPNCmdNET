using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace SoftEtherVPNCmdNET
{
    public sealed class AccountClassMap : CsvClassMap<Account>
    {
        public AccountClassMap()
        {
            Map(m => m.Status).Name("Status");
            Map(m => m.VPNConnectionSettingName).Name("VPN Connection Setting Name");
            Map(m => m.VPNServerHostname).Name("VPN Server Hostname");
            Map(m => m.VirtualHub).Name("Virtual Hub");
            Map(m => m.VirtualNetworkAdapterName).Name("Virtual Network Adapter Name");
        }
    }
    public class Account
    {
        public string VPNConnectionSettingName { get; set; }
        public string Status { get; set; }
        public string VPNServerHostname { get; set; }
        public string VirtualHub { get; set; }
        public string VirtualNetworkAdapterName { get; set; }
    }
}
