using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class ConditionId : AmazonMWSEnumeration
    {
        public static implicit operator ConditionId(string value) => new ConditionId { Value = value };

        public const string New = nameof(New);
        public const string Used = nameof(Used);
        public const string Collectible = nameof(Collectible);
        public const string Refurbished = nameof(Refurbished);
        public const string Preorder = nameof(Preorder);
        public const string Club = nameof(Club);
    }
}