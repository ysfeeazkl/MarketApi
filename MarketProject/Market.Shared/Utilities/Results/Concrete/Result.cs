using MarketProject.Shared.Utilities.Results.Abstract;
using MarketProject.Shared.Utilities.Results.ComplexTypes;

namespace MarketProject.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus, string message) : this(message)
        {
            ResultStatus = resultStatus;
        }
        public Result(string message)
        {
            Message = message;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
