using MarketProject.Shared.Entities.ComplexTypes;
using MarketProject.Shared.Utilities.Results.Abstract;

namespace MarketProject.Shared.Utilities.Results.Concrete
{
    public class SuccessApiResult : ApiResult
    {
        public SuccessApiResult(IResult result, string href) : base(result.ResultStatus, result.Message, HttpStatusCode.OK, href)
        {
        }
    }
}

