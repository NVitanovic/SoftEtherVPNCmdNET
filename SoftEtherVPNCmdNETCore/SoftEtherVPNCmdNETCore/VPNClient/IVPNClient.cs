using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEtherVPNCmdNETCore.VPNClient
{
    interface iVPNClient
    {
        string About();
        Dictionary<string,string> VersionGet();
        void PasswordSet(string password, bool remoteOnly = false);
        Dictionary<string, string> PasswordGet();
    }
}
