using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SoftEtherVPNCmdNET
{
    public class VpnCmdClient : VpnCmd
    {
        public VpnCmdClient(string hostport) : base(hostport,"",true,10000)
        { }
        public VpnCmdClient(string hostport,int timeout) : base(hostport, "", true, timeout)
        { }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///This displays the version information of this command line management utility. Included in the version information are the vpncmd version number, build number and build information.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response About()
        {
            return GeneralCommand("About","");
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Use this to get the version information of the currently managed VPN Client Service program.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response VersionGet()
        {
            return GeneralCommand("VersionGet", "");
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Set the password to connect to the VPN Client service.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response PasswordSet(string password, bool RemoteOnly = false)
        {
            return GeneralCommand("PasswordSet", password + " /REMOTEONLY:" + (RemoteOnly ? "yes" : "no"));
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get Password Setting to Connect to VPN Client Service.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response PasswordGet()
        {
            return GeneralCommand("PasswordGet", "");
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get List of Trusted CA Certificates.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response CertList()
        {
            return GeneralCommand("CertList", "");
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Add Trusted CA Certificate.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response CertAdd(string path)
        {
            return GeneralCommand("CertAdd", path);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Delete Trusted CA Certificate.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response CertDelete(string id)
        {
            return GeneralCommand("CertDelete", id);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get Trusted CA Certificate.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response CertGet(string id)
        {
            return GeneralCommand("CertDelete", id);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Use this to get an existing certificate from the list of CA certificates trusted by the VPN Client and save it as a file in X.509 format.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response CertGet(string id,string path)
        {
            return GeneralCommand("CertDelete", id + " /SAVECERT:\"" + path + '\"');
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get List of Usable Smart Card Types.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response SecureList()
        {
            return GeneralCommand("SecureList","");
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Select the Smart Card Type to Use.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response SecureSelect(string id)
        {
            return GeneralCommand("SecureSelect", id);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get ID of Smart Card Type to Use.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        public Response SecureGet()
        {
            return GeneralCommand("SecureGet", "");
        }

        public Response AccountConnect(string name)
        {
            return GeneralCommand("AccountConnect", name);
        }
        public Response AccountDisconnect(string name)
        {
            return GeneralCommand("AccountDisconnect", name);
        }
        public Response AccountStatus(string name)
        {
            return GeneralCommand("AccountStatusGet", name);
        }
    }
}
