using System;
using System.Collections.Generic;

namespace IPAddCalculator.Model
{
    public class Addrress
    {
        public string StrAddr { get; private set; }
        public List<int> AddrSegments { get; private set; }

        public Addrress(string addr)
        {
            StrAddr = addr;
            AddrSegments = GetSegmentsBy(addr);
            CheckAddrSegment();
        }

        private List<int> GetSegmentsBy(string addr)
        {
            List<int> segments = new List<int>();
            var strArr = addr.Split('.');
            foreach (var segment in strArr)
            {
                segments.Add(Convert.ToInt32(segment));
            }
            return segments;
        }

        private void CheckAddrSegment()
        {
            foreach (var segment in AddrSegments)
            {
                if(segment>=256||segment<0)
                    throw  new FormatException("字符串地址格式不正确");
            }
        }
    }
}