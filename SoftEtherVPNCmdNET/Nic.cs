using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace SoftEtherVPNCmdNET
{
    public sealed class NicClassMap : CsvClassMap<Nic>
    {
        public NicClassMap()
        {
            Map(m => m.VirtualNetworkAdapterName).Name("Virtual Network Adapter Name");
            Map(m => m.Status).Name("Status");
            Map(m => m.MACAddress).Name("MAC Address");
            Map(m => m.Version).Name("Version");
        }
    }
    public class Nic
    {
        public string VirtualNetworkAdapterName { get; set; }
        public string Status { get; set; }
        public string MACAddress { get; set; }
        public string Version { get; set; }
    }
}
