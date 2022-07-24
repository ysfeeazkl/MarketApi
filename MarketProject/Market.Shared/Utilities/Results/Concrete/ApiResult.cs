using MarketProject.Shared.Entities.ComplexTypes;
using MarketProject.Shared.Utilities.Results.ComplexTypes;

namespace MarketProject.Shared.Utilities.Results.Concrete
{
    public class ApiResult
    {
        public ApiResult(ResultStatus resultStatus, string message, HttpStatusCode statusCode, string href)
        {
            ResultStatus = resultStatus;
            Message = message;
            StatusCode = statusCode;
            Href = href;
        }
        public ApiResult()
        {

        }
        public string Href { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}

