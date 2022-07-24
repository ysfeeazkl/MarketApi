using MarketProject.Shared.Utilities.Results.Abstract;
using MarketProject.Shared.Utilities.Results.ComplexTypes;

namespace MarketProject.Shared.Utilities.Results.Concrete
{
    public class DataResult : IDataResult
    {
        public DataResult(ResultStatus resultStatus, Object data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, Object data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Object Data { get; }
    }
}
