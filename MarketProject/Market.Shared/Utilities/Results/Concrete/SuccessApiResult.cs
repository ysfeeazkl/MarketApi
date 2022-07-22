using Fahax.Shared.Entities.ComplexTypes;
using Fahax.Shared.Utilities.Results.Abstract;

namespace Fahax.Shared.Utilities.Results.Concrete
{
    public class SuccessApiResult : ApiResult
    {
        public SuccessApiResult(IResult result, string href) : base(result.ResultStatus, result.Message, HttpStatusCode.OK, href)
        {
        }
    }
}

