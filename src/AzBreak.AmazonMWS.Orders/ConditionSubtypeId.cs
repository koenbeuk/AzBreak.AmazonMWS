using AzBreak.AmazonMWS.Core;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS.Orders
{
    public class ConditionSubtypeId : AmazonMWSEnumeration
    {
        public static implicit operator ConditionSubtypeId(string value) => new ConditionSubtypeId { Value = value };

        public const string New = nameof(New);
        public const string Mint = nameof(Mint);
        public const string VeryGood = "Very Good";
        public const string Good = nameof(Good);
        public const string Acceptable = nameof(Acceptable);
        public const string Poor = nameof(Poor);
        public const string Club = nameof(Club);
        public const string OEM = nameof(OEM);
        public const string Warranty = nameof(Warranty);
        public const string RefurbishedWarranty = "Refurbished Warranty";
        public const string Refurbished = nameof(Refurbished);
        public const string OpenBox = "Open Box";
        public const string Any = nameof(Any);
        public const string Other = nameof(Other);
    }
}