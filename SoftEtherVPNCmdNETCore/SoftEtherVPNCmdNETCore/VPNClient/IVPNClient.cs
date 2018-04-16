using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEtherVPNCmdNETCore.VPNClient
{
    /// <summary>
    /// All commands in this interface should be the same as on the link:
    /// https://www.softether.org/4-docs/1-manual/6._Command_Line_Management_Utility_Manual/6.5_VPN_Client_Management_Command_Reference
    /// </summary>
    interface iVPNClient
    {
        string About();
        Dictionary<string,string> VersionGet();
        void PasswordSet(string password, bool remoteOnly = false);
        Dictionary<string, string> PasswordGet();
        Dictionary<string, string> CertList();
        void CertAdd(string path);
        void CertDelete(string id);
        void CertGet(string id, string saveCertPath);
        List<cSecureCard> SecureList();
        void SecureSelect(string id);
        //TODO: Not sure the return format of SecureGet();
        Dictionary<string, string> SecureGet(); 
        void NicCreate(string name);
        void NicDelete(string name);
        void NicUpgrade(string name);
        Dictionary<string, string> NicGetSetting(string name);
        void NicSetSetting(string name, string mac);
        void NicEnable(string name);
        void NicDisable(string name);
        List<cNic> NicList();
        List<cAccount> AccountList();
        void AccountCreate(string name, string server, string hub, string username, string nicName);
        void AccountSet(string name, string server, string hub);
        Dictionary<string, string> AccountGet(string name);
        void AccountDelete(string name);
        void AccountUsernameSet(string name, string username);
        void AccountAnonymousSet(string name);
        void AccountPasswordSet(string name, string password, eAuthenticationType type);
        void AccountCertSet(string name, string loadCert, string loadKey);
        void AccountCertGet(string name, string saveCert);
        void AccountEncryptDisable(string name);
        void AccountEncryptEnable(string name);
        void AccountCompressEnable(string name);
        void AccountCompressDisable(string name);
        void AccountProxyNone(string name);
        void AccountProxyHttp(string name, string server, string password);
        void AccountProxySocks(string name, string server, string password);
        void AccountServerCertEnable(string name);
        void AccountServerCertDisable(string name);
        void AccountServerCertSet(string name, string loadCert);
        void AccountServerCertDelete(string name);
        void AccountServerCertGet(string name, string saveCert);
        void AccountDetailSet(string name, int maxTCP, int interval, int ttl, bool half, bool bridge, bool monitor, bool noTrack, bool noQos);
        void AccountRename(string name, string newName);
        void AccountConnect(string name);
        void AccountDisconnect(string name);
        Dictionary<string, string> AccountStatusGet(string name);
        void AccountNicSet(string name, string nicName);
        void AccountStatusShow(string name);
        void AccountStatusHide(string name);
        void AccountSecureCertSet(string name, string certName, string keyName);
        void AccountRetrySet(string name, int num, int interval);
        void AccountStartupSet(string name);
        void AccountStartupRemove(string name);
        void AccountExport(string name, string savePath);
        void AccountImport(string path);
        void RemoteEnable();
        void RemoteDisable();
        void KeepEnable();
        void KeepDisable();
        void KeepSet(string host, eProtocol protocol, int interval);
        Dictionary<string, string> KeepGet();
        void MakeCert(string certificateName, string organization, string organizationUnit, string country, string state, string locale, int expires, string saveCert, string saveKey, string signKey = "", string signCert = "");
        void TrafficClient(string hostPort, int numTCP, eTrafficClientType type, int span, bool doubleResult, bool raw);
        //TODO: Can be tricky to be used as this command does not exits until enter is sent.
        void TrafficServer(int port);
        void Check();
    }
}
