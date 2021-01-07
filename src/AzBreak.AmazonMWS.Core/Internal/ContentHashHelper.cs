using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    static class ContentHashHelper
    {
        internal static async Task<byte[]> ComputeMD5HashBytes(Stream stream, CancellationToken cancellationToken = default)
        {
            const int bufferSize = 2048;
            var buffer = new byte[bufferSize];

            using (var md5Hash = MD5.Create())
            {
                int read;
                while (true)
                {
                    read = await stream.ReadAsync(buffer, 0, bufferSize, cancellationToken);
                    if (read == bufferSize)
                    {
                        md5Hash.TransformBlock(buffer, 0, read, null, 0);
                    }
                    else
                    {
                        md5Hash.TransformFinalBlock(buffer, 0, read);
                        break;
                    }
                }

                return md5Hash.Hash;
            }
        }

        internal static async Task<string> ComputeMD5Hash(Stream stream, CancellationToken cancellationToken = default)
        {
            var hashBytes = await ComputeMD5HashBytes(stream, cancellationToken);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
