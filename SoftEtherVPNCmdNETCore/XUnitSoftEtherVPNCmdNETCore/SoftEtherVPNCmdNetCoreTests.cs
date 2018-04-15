using System;
using Xunit;
using SoftEtherVPNCmdNETCore;
using System.Diagnostics;
using System.Threading;

namespace XUnitSoftEtherVPNCmdNETCore
{
    public class SoftEtherVPNCmdNetCoreTests
    {
        [Fact]
        public void CheckSettingOfBinary()
        {
            cSoftEtherVPNCmdNETCore cmd = new cSoftEtherVPNCmdNETCore("vpncmd");
            Assert.Equal(cmd.Binary, "vpncmd");
        }
        [Fact]
        public void CheckExecution()
        {
            cSoftEtherVPNCmdNETCore cmd = new cSoftEtherVPNCmdNETCore("vpncmd");
            var output = cmd.ExecuteCommand("127.0.0.1", "CLIENT", "VersionGet", "");
            Assert.Contains(",SoftEther VPN Client", output);
        }
        [Fact]
        public void CheckParse()
        {
            string output = "Item,Value\nTestItem,TestValue";
            cSoftEtherVPNCmdNETCore cmd = new cSoftEtherVPNCmdNETCore("vpncmd");
            var res = cmd.ParseCommand(output);
            Assert.Equal(1, res.Count);
            foreach(var pair in res)
            {
                Assert.Equal(pair.Key, "TestItem");
                Assert.Equal(pair.Value, "TestValue");
            }
        }
        [Fact]
        public void CheckConnectToVPN()
        {
            cSoftEtherVPNCmdNETCore cmd = new cSoftEtherVPNCmdNETCore();
            //Connect to VPN L10
            cmd.ExecuteCommand("127.0.0.1", "CLIENT", "AccountConnect", "L10");
            //Check connection status
            var res = cmd.ExecuteCommandAndParse("127.0.0.1", "CLIENT", "AccountStatusGet", "L10");
            Assert.Equal(res["VPN Connection Setting Name"], "L10");
        }
    }
}
