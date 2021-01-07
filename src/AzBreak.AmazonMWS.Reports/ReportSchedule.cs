using AzBreak.AmazonMWS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Reports
{
    public class ReportSchedule
    {
        /// <summary>
        /// The ReportType value requested.
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// A value of the Schedule that indicates how often a report request should be created.
        /// </summary>
        public Schedule Schedule { get; set; }

        /// <summary>
        /// The date when the next report request is scheduled to be submitted.
        /// </summary>
        public AmazonMWSDateTime ScheduledDate { get; set; }
    }
}
