using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBreak.AmazonMWS.Core;

namespace AzBreak.AmazonMWS.TestSuite
{
    public class ResponseStub : Response
    {
        public static ResponseStub CreateSuccess() => new ResponseStub
        {
            StatusCode = System.Net.HttpStatusCode.OK
        };

        public static ResponseStub CreateErrorResponse(ErrorCode code) => new ResponseStub
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Error = new ErrorResult
            {
                Code = code
            }
        };
    }
}
