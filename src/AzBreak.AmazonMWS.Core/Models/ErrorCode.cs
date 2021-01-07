using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    public struct ErrorCode
    {
        [XmlText]
        public string Value { get; set; }

        public override string ToString() => Value;

        public static implicit operator string(ErrorCode errorCode) => errorCode.Value;
        public static implicit operator ErrorCode(string value) => new ErrorCode { Value = value };

        public const string Unknown = nameof(Unknown);
        public const string InvalidAccessKeyId = nameof(InvalidAccessKeyId);
        public const string InvalidParameterValue = nameof(InvalidParameterValue);
        public const string RequestThrottled = nameof(RequestThrottled);
    }
}
