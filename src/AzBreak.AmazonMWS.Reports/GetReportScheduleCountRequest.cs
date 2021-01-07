using AzBreak.AmazonMWS.Core.Internal;
using System.Collections.Generic;

namespace AzBreak.AmazonMWS.Reports
{
    public class GetReportScheduleCountRequest
    {
        /// <summary>
        /// A structured list of ReportType enumeration values.	
        /// </summary>
        public IEnumerable<ReportType> ReportTypes { get; set; }

        internal IDictionary<string, object> ToParametersDictionary()
            => new ParameterDictionaryBuilder()
                .Add("ReportTypeList.Type", ReportTypes)
                .Parameters;
    }
}