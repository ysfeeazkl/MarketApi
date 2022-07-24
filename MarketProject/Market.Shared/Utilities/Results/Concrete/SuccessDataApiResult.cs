using MarketProject.Shared.Entities.ComplexTypes;
using MarketProject.Shared.Utilities.Results.Abstract;

namespace MarketProject.Shared.Utilities.Results.Concrete
{
    public class SuccessDataApiResult : ApiResult
    {
        public SuccessDataApiResult(IDataResult dataResult, string href) : base(dataResult.ResultStatus, dataResult.Message, HttpStatusCode.OK, href)
        {
            Data = dataResult.Data;
        }
        public Object Data { get; set; }
    }
}

