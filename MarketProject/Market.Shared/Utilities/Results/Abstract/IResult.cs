using Fahax.Shared.Utilities.Results.ComplexTypes;

namespace Fahax.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }// ResultStatus.Success // ResultStatus.Error
        public string Message { get; }
    }
}
