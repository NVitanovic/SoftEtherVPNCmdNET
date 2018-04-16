using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEtherVPNCmdNETCore.VPNClient
{
    public enum eAccountStatus { Connected, Offline }
    public enum eAuthenticationType { Standard, Radius }
    public enum eProtocol { TCP, UDP }
    public enum eTrafficClientType { Download, Upload, Full }
}
