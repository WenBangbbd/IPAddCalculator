using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAddCalculator.Model;

namespace IPAddCalculator.UnitTest
{
    class MaskTest
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void GetAMaskByString_ReturnNotNull()
        {
            string addr = "255.255.255.248";
            Mask mask = new Mask(addr);
            Assert.IsNotNull(mask);
            Assert.AreEqual(addr, mask.Addr.StrAddr);
        }

        [TestCase("255.255.1.248")]
        [TestCase("255.1.0.0")]
        public void GetAMaskByString_IfInputCanNotCreateAMask_ThrowException(string strAddr)
        {
            var ex = Assert.Catch<FormatException>(() => new Mask(strAddr));
            StringAssert.Contains("地址是无效掩码", ex.Message);
        }

        [TestCase("255.255.255.248", 29)]
        [TestCase("255.0.0.0", 8)]
        public void GetMaskBit_ReturnMaskBit(string maskAddr, int maskBit)
        {
            Mask mask = new Mask(maskAddr);
            Assert.AreEqual(maskBit, mask.Bit);
        }
        [TestCase(0,"0.0.0.0")]
        [TestCase(16, "255.255.0.0")]
        public void GetMaskByInt_AddrIsRelationWithInputInt(int maskBit,string strMaskAddr)
        {
            Mask mask=new Mask(maskBit);
            Assert.AreEqual(strMaskAddr,mask.Addr.StrAddr);
        }
    }
}
