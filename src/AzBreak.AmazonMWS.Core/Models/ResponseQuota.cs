using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public class ResponseQuota
    {
        public int Max { get; internal set; }
        public int Remaining { get; internal set; }
        public DateTimeOffset ServerDate { get; internal set; }
        public DateTimeOffset ResetsOn { get; internal set; }
        public TimeSpan ResetsIn => ResetsOn - ServerDate;
    }
}
