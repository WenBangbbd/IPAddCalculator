using System;
using IPAddCalculator.Model;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace IPAddCalculator.UnitTest
{
    public class AddrressTest
    {
        [Test]
        public void GetAddrress_InputString_ReturnNotNull()
        {
            string strAddr = "192.168.140.123";
            Addrress addr = new Addrress(strAddr);
            Assert.IsNotNull(addr);
            Assert.AreEqual(strAddr, addr.StrAddr);
        }
        [Test]
        public void AddrSegments_WhenGetAddress_AddrSegmentsIsRelationWithStrAddr()
        {
            string strAddr = "123.234.121.213";
            Addrress addr = new Addrress(strAddr);
            Assert.AreEqual(123, addr.AddrSegments[0]);
            Assert.AreEqual(234, addr.AddrSegments[1]);
            Assert.AreEqual(121, addr.AddrSegments[2]);
            Assert.AreEqual(213, addr.AddrSegments[3]);
        }

        [TestCase("1231.23.12.1")]
        [TestCase("1231.23.12.-1")]
        public void GetAddress_IfStrAddrIsInvilid_ThrwoException(string strAddr)
        {
            var ex = Assert.Catch<FormatException>(() => new Addrress(strAddr));
            StringAssert.Contains("字符串地址格式不正确", ex.Message);
        }
    }
}