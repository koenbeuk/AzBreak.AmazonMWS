using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AzBreak.AmazonMWS
{
    public class StreamedResponse : Response
    {
        Func<Task<Stream>> sourceAccessor;
        readonly long? expectedLength;

        public StreamedResponse(Func<Task<Stream>> sourceAccessor, long? expectedLength)
        {
            this.sourceAccessor = sourceAccessor ?? throw new ArgumentNullException(nameof(sourceAccessor));
            this.expectedLength = expectedLength;
        }

        public async Task<Stream> ReadAsStream()
        {
            if (sourceAccessor == null)
            {
                throw new InvalidOperationException("Can only read the response once");
            }

            var source = await sourceAccessor();
            sourceAccessor = null; // disable further read attempts

            return source;
        }

        public async Task<string> ReadAsString()
        {
            using (var sourceStream = await ReadAsStream())
            using (var streamReader = new StreamReader(sourceStream))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        static TModel InternalReadAs<TModel>(Stream sourceStream)
        {
            var serializer = new XmlSerializer(typeof(TModel));
            return (TModel)serializer.Deserialize(sourceStream);
        }

        /// <summary>
        /// Uses XML serialization to deserialize the given model as TModel
        /// Warning: this method will still block due to the nature of XMLSerialization, <see cref="ReadXmlAsAsync{TModel}(CancellationToken)"/> for an alternative that is trully async
        /// </summary>
        public TModel ReadXmlAs<TModel>()
        {
            using (var sourceStream = ReadAsStream().GetAwaiter().GetResult())
            {
                return InternalReadAs<TModel>(sourceStream);
            }
        }

        /// <summary>
        /// Uses XML serialization to deserialize the given model as TModel
        /// Warning: this method will first perform a copy to memory, <see cref="ReadXmlAs{TModel}"/> for an alternative that is not async but more performant.
        /// </summary>
        public async Task<TModel> ReadXmlAsAsync<TModel>(CancellationToken cancellationToken = default)
        {
            using (var sourceStream = await ReadAsStream())
            {
                // todo: when the actual length is equal or larger than the LOH min length threshold, then this will generate garbage on the LOH, even though we know for a fact that its short-lived
                Stream bufferedStream;
                if (expectedLength != null && expectedLength <= int.MaxValue)
                unchecked
                {
                    bufferedStream = new MemoryStream((int)expectedLength);
                }
                else
                {
                    bufferedStream = new MemoryStream();
                }

                using (bufferedStream)
                {
                    await sourceStream.CopyToAsync(bufferedStream, 81920, cancellationToken);
                    bufferedStream.Position = 0;

                    return InternalReadAs<TModel>(bufferedStream);
                }
            }
        }
    }
}
