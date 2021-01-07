using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    static class DateTimeHelper
    {
        const string AmazonMWSDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        const string AmazonMWSDateTimeFormatWithPrecision = "yyyy-MM-ddTHH:mm:ss.fffZ";

        static readonly string[] ParseableFormats = { AmazonMWSDateTimeFormat, AmazonMWSDateTimeFormatWithPrecision };
        
        static internal DateTimeOffset? ToDateTimeOffset(string value)
        {
            if (DateTimeOffset.TryParseExact(value, ParseableFormats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        static internal string ToIsoDateTimeString(DateTimeOffset dateTimeOffset)
        {
            var utcDateTime = dateTimeOffset.ToUniversalTime();
            // If you are using .NET, you must not send overly specific timestamps, due to different interpretations of how extra time precision should be dropped. 
            // To avoid overly specific timestamps, manually construct dateTime objects with no more than millisecond precision.
            var dateTimeWithLessPrecision = new DateTime(utcDateTime.Year, utcDateTime.Month, utcDateTime.Day, utcDateTime.Hour, utcDateTime.Minute, utcDateTime.Second, DateTimeKind.Utc);

            return dateTimeWithLessPrecision.ToString(AmazonMWSDateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
