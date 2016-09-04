using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SoftEtherVPNCmdNET
{
    public class VpnCmdServer : VpnCmd
    {
        public VpnCmdServer(string hostport, string password) : base(hostport, password, false,10000)
        { }
        public VpnCmdServer(string hostport, string password, int timeout) : base(hostport, password, false, timeout)
        { }
    }
}
