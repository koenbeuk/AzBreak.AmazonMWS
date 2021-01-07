using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    public static class HttpResponseHeaderExtensions
    {
        public static string GetSingleHeaderValue(this HttpResponseHeaders headers, string headerName)
        {
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headerName == null)
                throw new ArgumentNullException(nameof(headerName));

            if (headers.TryGetValues(headerName, out var values))
            {
                var firtValue = values.SingleOrDefault();
                return firtValue;
            }
            else
            {
                return null;
            }
        }
        public static int? GetSingleHeaderValueAsInt(this HttpResponseHeaders headers, string headerName)
        {
            var value = GetSingleHeaderValue(headers, headerName);
            if (value != null && int.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public static DateTimeOffset? GetSingleHeaderValueAsDateTime(this HttpResponseHeaders headers, string headerName)
        {
            var value = GetSingleHeaderValue(headers, headerName);
            if (value != null)
            {
                return DateTimeHelper.ToDateTimeOffset(value);
            }
            else
            {
                return null;
            }
        }
    }
}
