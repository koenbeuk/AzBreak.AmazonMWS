using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{

    [Serializable]
    public class AmazonMWSResponseException : Exception
    {
        public ErrorResult Error { get; }

        internal AmazonMWSResponseException(ErrorResult errorResult)
            : base(errorResult.Message)
        {
            this.Error = errorResult;
        }

        protected AmazonMWSResponseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
