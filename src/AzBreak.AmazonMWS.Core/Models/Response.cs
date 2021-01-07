using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    public abstract class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public ErrorResult Error { get; set; }
        public ResponseQuota Quota { get; set; }
        public ResponseMetadata Metadata { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public bool Success => StatusCode == HttpStatusCode.OK;
        /// <summary>
        /// Throw an AmazonMWSResponseException when the response contains an error
        /// </summary>
        public void EnsureSuccess()
        {
            if (!Success)
            {
                // todo: throw specialized exception when quota has been reached
                throw new AmazonMWSResponseException(Error);
            }
        }
    }
}
