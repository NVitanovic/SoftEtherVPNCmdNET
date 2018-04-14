using System;
using Xunit;
using SoftEtherVPNCmdNETCore;

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
        public void TestParse()
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
    }
}
