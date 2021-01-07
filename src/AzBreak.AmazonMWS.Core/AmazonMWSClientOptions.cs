using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public class AmazonMWSClientOptions
    {
        /// <summary>
        /// The default endpoint being targeted by this client
        /// </summary>
        public string RegionEndpoint { get; set; }
        /// <summary>
        /// To create a User-Agent header, begin with the name of your application, followed by a forward slash, 
        /// followed by the version of the application, followed by a space, an opening parenthesis, the Language name value pair, and a closing parenthesis. 
        /// The Language parameter is a required attribute, but you can add additional attributes separated by semicolons.
        /// </summary>
        public string UserAgent { get; set; } = "AzBreak/1.0 (Language=NetStandard2)";
        /// <summary>
        /// Your Amazon MWS account is identified by your access key Id, which Amazon MWS uses to look up your Secret Access Key.
        /// (a 20-character, alphanumeric identifier)
        /// </summary>
        public string AWSAccessKeyId { get; set; } 
        /// <summary>
        /// Represents the authorization of a specific developer of a web application by a specific Amazon seller.
        /// </summary>
        public string MWSAuthToken { get; set; }
        /// <summary>
        /// Your seller identifier.
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// Authentication is performed using your access key Id to locate your Secret Key (a 40-character identifier)
        /// </summary>
        public string SecretKey { get; set; }

        public void EnsureValid()
        {
            if (string.IsNullOrEmpty(RegionEndpoint))
                throw new ArgumentException("Missing a region endpoint");
            if (string.IsNullOrEmpty(UserAgent))
                throw new ArgumentException("Missing an useragent");
            if (string.IsNullOrEmpty(SellerId))
                throw new ArgumentException("Missing a seller id");
            if (string.IsNullOrEmpty(SecretKey))
                throw new ArgumentException("Missing a secret key");
            if (string.IsNullOrEmpty(AWSAccessKeyId))
                throw new ArgumentException("Missing an access key");
        }

        public static AmazonMWSClientOptions Create(string regionEndpoint, string sellerId, string secretKey, string awsAccessKeyId)
        {
            return new AmazonMWSClientOptions
            {
                RegionEndpoint = regionEndpoint,
                SellerId = sellerId,
                SecretKey = secretKey,
                AWSAccessKeyId = awsAccessKeyId
            };
        }

        public AmazonMWSClientOptions Clone() => (AmazonMWSClientOptions)MemberwiseClone();
    }
}
