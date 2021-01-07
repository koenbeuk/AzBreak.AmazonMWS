using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    sealed class AmazonMWSV2RequestUrlBuilder
    {
        internal AmazonMWSV2RequestUrlBuilder(SignatureMethod method = SignatureMethod.HmacSHA256)
        {
            this.SignatureMethod = method;
        }

        public SignatureVersion SignatureVersion => SignatureVersion.v2;

        public SignatureMethod SignatureMethod { get; }

        public Uri CreateRequestUri(Request request, AmazonMWSClientOptions options)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var sortedParameters = new SortedDictionary<string, object>(StringComparer.Ordinal);
            if (request.Parameters != null)
            {
                foreach (var parameter in request.Parameters)
                {
                    sortedParameters.Add(parameter.Key, parameter.Value);
                }
            }
            sortedParameters["Action"] = request.Action ?? throw new ArgumentException("Request is missing an action", nameof(request));
            sortedParameters["SignatureMethod"] = SignatureMethod;
            sortedParameters["Timestamp"] = DateTime.UtcNow;
            sortedParameters["AWSAccessKeyId"] = options.AWSAccessKeyId;
            sortedParameters["SellerId"] = options.SellerId;

            if (!string.IsNullOrEmpty(options.MWSAuthToken))
                sortedParameters["MWSAuthToken"] = options.MWSAuthToken;

            switch (SignatureVersion)
            {
                case SignatureVersion.v1:
                    throw new NotSupportedException("V1 signatures are not implemented");
                case SignatureVersion.v2:
                    sortedParameters["SignatureVersion"] = "2";
                    break;
                default:
                    throw new InvalidOperationException("Unsupported signature version");
            }

            var path = $"/{request.Resource}/{request.Version}";
            var queryString = QueryHelper.BuildCanonicalQueryString(sortedParameters);

            // If Signature Version is 2, string to sign is based on following:
            // 1. The HTTP Request Method followed by an ASCII newline (%0A)
            // 2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
            // 3. The URL encoded HTTP absolute path component of the URI (up to but not including the query string parameters); if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
            // 4. The concatenation of all query string components (names and values) as UTF-8 characters which are URL encoded as per RFC 3986 (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
            //    Parameter names are separated from their values by the '=' character (ASCII character 61), even if the value is empty. Pairs of parameter and values are separated by the '&' character (ASCII code 38).
            var signature = string.Join("\n", "POST", HostFromEndpoint(options.RegionEndpoint).ToLowerInvariant(), path, queryString);
            var hashedSignature = Hash(options.SecretKey, signature);

            queryString += $"&Signature={WebUtility.UrlEncode(hashedSignature)}";
            return new UriBuilder(options.RegionEndpoint)
            {
                Path = path,
                Query = queryString
            }.Uri;
        }

        string HostFromEndpoint(string marketplace)
        {
            if (Uri.TryCreate(marketplace, UriKind.Absolute, out var parsedMarketplaceUri))
            {
                return parsedMarketplaceUri.Host;
            }
            else
            {
                throw new InvalidOperationException("Provided region endpoint url is not in a valid url format");
            }
        }

        string Hash(string key, string signature)
        {
            var encoding = Encoding.ASCII;
            var keyBytes = encoding.GetBytes(key);
            var signatureBytes = encoding.GetBytes(signature);

            KeyedHashAlgorithm algorithm;

            switch (SignatureMethod)
            {
                case SignatureMethod.HmacSHA1:
                    algorithm = new HMACSHA1(keyBytes);
                    break;
                case SignatureMethod.HmacSHA256:
                    algorithm = new HMACSHA256(keyBytes);
                    break;
                default:
                    throw new InvalidOperationException("Unsupported hash method");
            }

            var hashedBytes = algorithm.ComputeHash(signatureBytes);
            var base64String = Convert.ToBase64String(hashedBytes);

            return base64String;
        }
    }
}
