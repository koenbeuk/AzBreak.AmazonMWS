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
    sealed class MD5VerifiedStream : Stream
    {
        readonly Stream inner;
        readonly byte[] expectedHash;
        readonly MD5 hasher;

        int FinishReading(byte[] buffer, int offset, int count)
        {
            if (count == 0)
            {
                hasher.TransformFinalBlock(buffer, 0, 0);
                var hash = hasher.Hash;

                if (!hash.SequenceEqual(expectedHash))
                    throw new InvalidOperationException("Response was malformed, MD5 hash did not match");
            }
            else
            {
                hasher.TransformBlock(buffer, offset, count, null, 0);
            }

            return count;
        }

        public MD5VerifiedStream(Stream inner, byte[] expectedHash)
        {
            this.inner = inner ?? throw new ArgumentNullException(nameof(inner));
            this.expectedHash = expectedHash ?? throw new ArgumentNullException(nameof(expectedHash));
            this.hasher = MD5.Create();
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var red = inner.Read(buffer, offset, count);
            return FinishReading(buffer, offset, red);
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                inner.Dispose();
                hasher.Dispose();
            }
        }
    }
}
