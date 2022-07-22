using Fahax.Shared.Entities.Concrete;

namespace Fahax.Shared.Utilities.Exceptions
{
    public class ValidationErrorsException : Exception
    {
        public ValidationErrorsException(string message, IEnumerable<Error> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }
        public IEnumerable<Error> ValidationErrors { get; set; }
    }
}

