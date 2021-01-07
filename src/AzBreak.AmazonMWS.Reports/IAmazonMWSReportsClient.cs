using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.Reports
{
    public interface IAmazonMWSReportsClient
    {

        /// <summary>
        /// Creates a report request and submits the request to Amazon MWS.
        /// </summary>
        /// <remarks>
        /// The RequestReport operation creates a report request. Amazon MWS processes the report request and when the report is completed, sets the status of the report request to _DONE_. Reports are retained for 90 days.
        /// You specify what marketplaces you want a report to cover by supplying a list of marketplace IDs to the optional MarketplaceIdList request parameter when you call the RequestReport operation.If you do not specify a marketplace ID, your home marketplace ID is used.Note that the MarketplaceIdList request parameter is not used in JP or CN
        /// The RequestReport operation has a maximum request quota of 15 and a restore rate of one request every minute.For definitions of throttling terminology and for a complete explanation of throttling, see Throttling: Limits to how often you can submit requests in the Amazon MWS Developer Guide.
        /// </remarks>
        Task<Response<RequestReportResult>> RequestReport(RequestReportRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of report requests that you can use to get the ReportRequestId for a report.
        /// </summary>
        /// <remarks>
        /// The GetReportRequestList operation returns a list of report requests that match the query parameters. You can specify query parameters for report status, date range, and report type. The list contains the ReportRequestId for each report request. You can obtain ReportId values by passing the ReportRequestId values to the GetReportList operation.
        /// In the first request, a maximum of 100 report requests are returned.If there are additional report requests to return, HasNext is returned set to true in the response . To retrieve all the results, you can pass the value of the NextToken parameter to call GetReportRequestListByNextToken operation iteratively until HasNext is returned set to false.
        /// </remarks>
        Task<Response<GetReportRequestListResult>> GetReportRequestList(GetReportRequestListRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of report requests using the NextToken, which was supplied by a previous request to either GetReportRequestListByNextToken or GetReportRequestList, where the value of HasNext was true in that previous request.
        /// </summary>
        /// <remarks>
        /// The GetReportRequestListByNextToken operation returns a list of report requests that match the query parameters. This operation uses the NextToken, which was supplied by a previous request to either GetReportRequestListByNextToken or a request to GetReportRequestList, where the value of HasNext was true in that previous request.
        /// </remarks>
        Task<Response<GetReportRequestListResult>> GetReportRequestListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a count of report requests that have been submitted to Amazon MWS for processing.
        /// </summary>
        /// <remarks>
        /// The GetReportRequestCount returns the total number of report requests that have been submitted to Amazon MWS for processing.
        /// </remarks>
        Task<Response<GetReportRequestCountResult>> GetReportRequestCount(GetReportRequestCountRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels one or more report requests.
        /// </summary>
        /// <remarks>
        /// The CancelReportRequests operation cancels one or more report requests, returning the count of the canceled report requests and the report request information. You can cancel more than 100 report requests, but information is only returned for the first 100 report requests canceled. To return information on a greater number of canceled report requests, use the GetReportRequestList operation.
        /// Note: If report requests have already begun processing, they cannot be canceled.
        /// </remarks>
        Task<Response<CancelReportRequestsResult>> CancelReportRequests(CancelReportRequestsRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of reports that were created in the previous 90 days.
        /// </summary>
        /// <remarks>
        /// The GetReportList operation returns a list of reports that were created in the previous 90 days that match the query parameters. A maximum of 100 results can be returned in one request. If there are additional results to return, HasNext is returned set to true in the response. To retrieve all the results, you can pass the value of the NextToken parameter to the GetReportListByNextToken operation iteratively until HasNext is returned set to false.
        /// </remarks>
        Task<Response<GetReportListResult>> GetReportList(GetReportListRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of reports using the NextToken, which was supplied by a previous request to either GetReportListByNextToken or GetReportList, where the value of HasNext was true in the previous call.
        /// </summary>
        /// <remarks>
        /// The GetReportListByNextToken operation returns a list of reports that match the query parameters, using the NextToken, which was supplied by a previous call to either GetReportListByNextToken or a call to GetReportList, where the value of HasNext was true in the previous call.
        /// </remarks>
        Task<Response<GetReportListResult>> GetReportListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a count of report requests that have been submitted to Amazon MWS for processing.
        /// </summary>
        /// <remarks>
        /// The GetReportRequestCount returns the total number of report requests that have been submitted to Amazon MWS for processing.
        /// </remarks>
        Task<Response<GetReportCountResult>> GetReportCount(GetReportCountRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the contents of a report and the Content-MD5 header for the returned report body.
        /// </summary>
        /// <remarks>
        /// The GetReport operation returns the contents of a report and the Content-MD5 header for the returned report body. Reports are retained for 90 days from the time they are generated.
        /// You should compute the MD5 hash of the HTTP body and compare that with the returned Content- MD5 header value.If they do not match, it means the body was corrupted during transmission.If the report is corrupted, you should discard the result and automatically retry the request up to three more times.Please notify Amazon MWS if you receive a corrupted report body.The client library for the Reports API section, found on the Amazon MWS website, contains code for processing and comparing Content-MD5 headers. For more information on working with the Content-MD5 header, see the Amazon MWS Developer Guide.
        /// </remarks>
        Task<StreamedResponse> GetReport(string reportId, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates, updates, or deletes a report request schedule for a specified report type.
        /// </summary>
        /// <remarks>
        /// The ManageReportSchedule operation creates, updates, or deletes a report request schedule for a particular report type. Only Order Reports and Amazon Product Ads Reports can be scheduled.
        /// By using a combination of the ReportType and Schedule values, Amazon MWS determines which action you want to perform.If no combination of ReportType and Schedule exists, then a new report request schedule is created.If the ReportType is already scheduled but with a different Schedule value, then the report request schedule is updated to use the new Schedule value.If you pass in a ReportType and set the Schedule value to _NEVER_ in the request, the report request schedule for that ReportType is deleted.
        /// </remarks>
        Task<Response<ManageReportScheduleResult>> ManageReportSchedule(ManageReportScheduleRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of order report requests that are scheduled to be submitted to Amazon MWS for processing.
        /// </summary>
        /// <remarks>
        /// The GetReportScheduleList operation returns a list of scheduled order report requests that match the query parameters. Only Order Reports and Amazon Product Ads Reports can be scheduled. A maximum number of 100 results can be returned in one request.
        /// </remarks>
        Task<Response<GetReportScheduleListResult>> GetReportScheduleList(GetReportScheduleListRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Currently this operation can never be called because the GetReportScheduleList operation cannot return more than 100 results. It is included for future compatibility.
        /// </summary>
        Task<Response<GetReportScheduleListResult>> GetReportScheduleListByNextToken(string nextToken, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a count of order report requests that are scheduled to be submitted to Amazon MWS.
        /// </summary>
        /// <remarks>
        /// The GetReportScheduleCount operation returns a count of report requests that are scheduled to be submitted to Amazon MWS. Only Order Reports can be scheduled.
        /// </remarks>
        Task<Response<GetReportScheduleCountResult>> GetReportScheduleCount(GetReportScheduleCountRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the acknowledged status of one or more reports.
        /// </summary>
        /// <remarks>
        /// The UpdateReportAcknowledgements operation is an optional request that updates the acknowledged status of one or more reports. Use this operation if you want Amazon MWS to remember the acknowledged status of your reports. To keep track of which reports you have already received, it is a good practice to acknowledge reports after you have received and stored them successfully. Then, when you submit a GetReportList request, you can specify to receive only reports that have not yet been acknowledged.
        /// To retrieve reports that have been lost, set the Acknowledged to false and then submit a GetReportList request.This action returns a list of all reports within the previous 90 days that match the query parameters.
        /// Note: When submitting the GetReportList or GetReportListByNextToken operations, be sure that HasNext returns false before submitting the UpdateReportAcknowledgements operation.This helps to ensure that all of the reports that match your query parameters are returned.
        /// </remarks>
        Task<Response<UpdateReportAcknowledgementsResult>> UpdateReportAcknowledgements(UpdateReportAcknowledgementsRequest request, AmazonMWSClientOptions clientOptions = null, CancellationToken cancellationToken = default);
    }
}