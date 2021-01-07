using AzBreak.AmazonMWS.Core;
using AzBreak.AmazonMWS.Core.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Reports
{
    public class AmazonMWSReportsClient : IAmazonMWSReportsClient
    {
        const string resourceName = "Reports";
        const string version = "2009-01-01";

        readonly IAmazonMWSChannel channel;

        public AmazonMWSReportsClient(IAmazonMWSChannel channel)
        {
            this.channel = channel ?? throw new ArgumentNullException(nameof(channel));
        }

        public Task<Response<RequestReportResult>> RequestReport(RequestReportRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<RequestReportResult>(new Request { Resource = resourceName, Version = version, Action = "RequestReport", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportRequestListResult>> GetReportRequestList(GetReportRequestListRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportRequestListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportRequestList", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportRequestListResult>> GetReportRequestListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportRequestListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportRequestListByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportRequestCountResult>> GetReportRequestCount(GetReportRequestCountRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportRequestCountResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportRequestCount", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<CancelReportRequestsResult>> CancelReportRequests(CancelReportRequestsRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<CancelReportRequestsResult>(new Request { Resource = resourceName, Version = version, Action = "CancelReportRequests", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportListResult>> GetReportList(GetReportListRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportList", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportListResult>> GetReportListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportListByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportCountResult>> GetReportCount(GetReportCountRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportCountResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportCount", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<StreamedResponse> GetReport(string reportId, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute(new Request { Resource = resourceName, Version = version, Action = "GetReport", Parameters = new ParameterDictionaryBuilder().Add("ReportId", reportId).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<ManageReportScheduleResult>> ManageReportSchedule(ManageReportScheduleRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<ManageReportScheduleResult>(new Request { Resource = resourceName, Version = version, Action = "ManageReportSchedule", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportScheduleListResult>> GetReportScheduleList(GetReportScheduleListRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportScheduleListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportScheduleList", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        /// <summary>
        /// Currently this operation can never be called because the GetReportScheduleList operation cannot return more than 100 results. It is included for future compatibility.
        /// </summary>
        public Task<Response<GetReportScheduleListResult>> GetReportScheduleListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportScheduleListResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportScheduleListByNextToken", Parameters = new ParameterDictionaryBuilder().Add("NextToken", nextToken).Parameters, ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<GetReportScheduleCountResult>> GetReportScheduleCount(GetReportScheduleCountRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<GetReportScheduleCountResult>(new Request { Resource = resourceName, Version = version, Action = "GetReportScheduleCount", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);

        public Task<Response<UpdateReportAcknowledgementsResult>> UpdateReportAcknowledgements(UpdateReportAcknowledgementsRequest request, AmazonMWSClientOptions clientOptions, CancellationToken cancellationToken)
            => channel.Execute<UpdateReportAcknowledgementsResult>(new Request { Resource = resourceName, Version = version, Action = "UpdateReportAcknowledgements", Parameters = request.ToParametersDictionary(), ClientOptions = clientOptions }, cancellationToken);
    }
}
