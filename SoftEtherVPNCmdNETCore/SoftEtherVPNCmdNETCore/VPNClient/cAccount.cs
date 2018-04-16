using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEtherVPNCmdNETCore.VPNClient
{
    public class cAccount
    {
        public string VPNConnectionSettingName { get; set; }
        public eAccountStatus Status { get; set; }
        public string VPNServerHostname { get; set; }
        public string VirtualHub { get; set; }
        public string VirtualNetworkAdapterName { get; set; }
    }
}
