using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CsvHelper;
using System.IO;

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
        ///<param name="password">Specify the password you wish to set. You can delete the password setting by specifying "none".</param>
        ///<param name="RemoteOnly">Specify "true" to only require the password to be input when operation is done remotely (from a computer that is not localhost). This stops the password being required when the connection is from localhost. When this parameter is omitted, it will be regarded as "false".</param>
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
        ///<param name="path">Path to the X.509 file.</param>
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
        ///<param name="id">Specify the ID of the certificate to delete.</param>
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
        ///<param name="id">Specify the ID of the certificate to get.</param>
        public Response CertGet(string id)
        {
            return GeneralCommand("CertGet", id);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Use this to get an existing certificate from the list of CA certificates trusted by the VPN Client and save it as a file in X.509 format.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="id">Specify the ID of the certificate to get.</param>
        ///<param name="path">Specify the file name to save the certificate you obtained.</param>
        public Response CertGet(string id,string path)
        {
            return GeneralCommand("CertGet", id + " /SAVECERT:\"" + path + '\"');
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
        ///<param name="id">Specify the ID of the smart card type.</param>
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
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Create New Virtual Network Adapter.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicCreate(string name)
        {
            //we fix the problem if the process is killed for hanging more than specified timeout
            timeoutOverride = true;
            return GeneralCommand("NicCreate", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Delete Virtual Network Adapter.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicDelete(string name)
        {
            //we fix the problem if the process is killed for hanging more than specified timeout
            timeoutOverride = true;
            return GeneralCommand("NicDelete", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Upgrade Virtual Network Adapter Device Driver.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicUpgrade(string name)
        {
            //we fix the problem if the process is killed for hanging more than specified timeout
            timeoutOverride = true;
            return GeneralCommand("NicUpgrade", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get Virtual Network Adapter Setting.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicGetSetting(string name)
        {
            return GeneralCommand("NicGetSetting", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Change Virtual Network Adapter Setting.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        ///<param name="mac">Specify the MAC address you wish to set. Specify a 6-byte hexadecimal string for the MAC address. Example: 00:AC:01:23:45:67 or 00-AC-01-23-45-67</param>
        public Response NicSetSetting(string name,string mac)
        {
            return GeneralCommand("NicSetSetting", name + " /MAC:" + mac);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Enable Virtual Network Adapter.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicEnable(string name)
        {
            return GeneralCommand("NicEnable", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Disable Virtual Network Adapter.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the virtual network adapter.</param>
        public Response NicDisable(string name)
        {
            return GeneralCommand("NicDisable", name);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get List of Virtual Network Adapters.
        ///</summary>
        ///<returns>
        ///Returns IEnumerable<Nic> object that contains other objects, it can be converted to the list using .ToList().
        ///</returns>
        public IEnumerable<Nic> NicList()
        {
            Response r = GeneralCommand("NicList", "");

            if (r.Success)
            {
                string text = r.Info.Substring(r.Info.IndexOf("\n\n"));
                var csv = new CsvReader(new StringReader(text));
                csv.Configuration.RegisterClassMap<NicClassMap>();
                var records = csv.GetRecords<Nic>();
                return records;
            }
            return null;
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Get List of VPN Connection Settings.
        ///</summary>
        ///<returns>
        ///Returns IEnumerable<Account> object that contains other objects, it can be converted to the list using .ToList().
        ///</returns>
        public IEnumerable<Account> AccountList()
        {
            Response r = GeneralCommand("AccountList", "");

            if (r.Success)
            {
                string text = r.Info.Substring(r.Info.IndexOf("\n\n"));
                var csv = new CsvReader(new StringReader(text));
                csv.Configuration.RegisterClassMap<AccountClassMap>();
                var records = csv.GetRecords<Account>();
                return records;
            }
            return null;
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Create New VPN Connection Setting.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the VPN Connection Setting to create.</param>
        ///<param name="server">Specify the host name and port number of the destination VPN Server using the format [host name:port number]. You can also specify by IP address.</param>
        ///<param name="hub">Specify the Virtual Hub on the destination VPN Server.</param>
        ///<param name="username">Specify the user name to use for user authentication when connecting to the destination VPN Server.</param>
        ///<param name="nic">Specify the virtual network adapter to use to connect.</param>
        public Response AccountCreate(string name,string server,string hub,string username, string nic)
        {
            return GeneralCommand("AccountCreate", name + " /SERVER:" + server + " /HUB:" + hub + " /USERNAME:" + username + " /NICNAME:" + nic);
        }
        //------------------------------------------------------------------------------------------------------
        ///<summary>
        ///Set the VPN Connection Setting Connection Destination.
        ///</summary>
        ///<returns>
        ///Returns Response object that contains boolean Success and Info string with more details.
        ///</returns>
        ///<param name="name">Specify the name of the VPN Connection Setting to create.</param>
        ///<param name="server">Specify the host name and port number of the destination VPN Server using the format [host name:port number]. You can also specify by IP address.</param>
        ///<param name="hub">Specify the Virtual Hub on the destination VPN Server.</param>
        public Response AccountSet(string name, string server, string hub)
        {
            return GeneralCommand("AccountSet", name + " /SERVER:" + server + " /HUB:" + hub);
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
        //TODO: Fix all Get functions so they return class with key value or dictonary.
        //TODO: Finish all other functions.
    }
}
