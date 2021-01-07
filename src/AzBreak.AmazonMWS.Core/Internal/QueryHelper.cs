using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    static class QueryHelper
    {
        static string MapParameterValue(object value)
        {
            switch (value)
            {
                case null:
                    return null;
                case DateTime d:
                    return DateTimeHelper.ToIsoDateTimeString(d);
                case DateTimeOffset d:
                    return DateTimeHelper.ToIsoDateTimeString(d);
                default:
                    return value.ToString();
            }
        }

        static internal string BuildCanonicalQueryString(IReadOnlyDictionary<string, object> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var queryBuilder = new StringBuilder();
            foreach (var parameter in parameters)
            {
                if (parameter.Key != null)
                {
                    if (queryBuilder.Length > 0)
                        queryBuilder.Append("&");

                    queryBuilder.Append(WebUtility.UrlEncode(parameter.Key));
                    queryBuilder.Append("="); // Separate the encoded parameter names from their encoded values with the equals sign ( = ) (ASCII character 61), even if the parameter value is empty.

                    if (parameter.Value != null)
                    {
                        var parameterValue = MapParameterValue(parameter.Value);
                        queryBuilder.Append(WebUtility.UrlEncode(parameterValue));
                    }
                }
            }

            return queryBuilder.ToString();
        }
    }
}
