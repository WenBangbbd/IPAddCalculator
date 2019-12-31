using System;
using System.Linq;
using System.Runtime.CompilerServices;
using IPAddCalculator.Model.Extension;

namespace IPAddCalculator.Model
{
    public class Mask
    {
        public const int SEGMENT_BIT = 8;
        public Addrress Addr { get; set; }
        public double Bit
        {
            get { return Addr.AddrSegments.Sum(seg => seg.GetOneCountsForBinary()); }
        }

        public Mask(string addr)
        {
            Addr = new Addrress(addr);
            StrAddrCanCreateAMask();
        }

        public Mask(int maskBit)
        {
            Addr = new Addrress(GetStrAddBy(maskBit));
            StrAddrCanCreateAMask();
        }


        private void StrAddrCanCreateAMask()
        {
            string strAllAddrBinary = string.Empty;
            foreach (var segment in Addr.AddrSegments)
            {
                strAllAddrBinary += Convert.ToString(segment, 2).PadLeft(8, '0');
            }

            int firstZeroIndex = strAllAddrBinary.IndexOf('0');
            int lastOneIndex = strAllAddrBinary.LastIndexOf('1');
            if (firstZeroIndex <= lastOneIndex)
                throw new FormatException("地址是无效掩码");
        }

        private string GetStrAddBy(int maskBit)
        {
            string strAddrBinary = string.Empty;
            for (int i = 0; i < maskBit; i++)
            {
                strAddrBinary += "1";
            }
            strAddrBinary = strAddrBinary.PadRight(32, '0');
            string strAddr = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                strAddr += Convert.ToInt32(strAddrBinary.Substring(0, 8)).ToString();
                strAddr += '.';
            }
            strAddr = strAddr.Remove(strAddr.Length - 1);
            return strAddr;
        }
    }
}