using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS
{
    public interface IAmazonMWSChannel
    {
        AmazonMWSClientOptions Options { get; }
        Task<Response<TResult>> Execute<TResult>(Request request, CancellationToken cancellationToken = default);
        Task<StreamedResponse> Execute(Request request, CancellationToken cancellationToken = default);
    }
}
