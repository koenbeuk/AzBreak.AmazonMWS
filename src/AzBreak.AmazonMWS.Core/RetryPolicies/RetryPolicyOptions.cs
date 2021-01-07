using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.RetryPolicies
{
    public class RetryPolicyOptions
    {
        public TimeSpan InitialRetryDelay { get; set; } = TimeSpan.FromSeconds(3);
        public int RetryAttempts { get; set; } = 5;
        public bool ExponentialBackoff { get; set; } = true;
    }
}
