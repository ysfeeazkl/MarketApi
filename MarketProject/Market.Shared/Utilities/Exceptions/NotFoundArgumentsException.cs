using Fahax.Shared.Entities.Concrete;

namespace Fahax.Shared.Utilities.Exceptions
{
    public class NotFoundArgumentsException : Exception
    {
        public NotFoundArgumentsException(string message, IEnumerable<Error> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }
        public IEnumerable<Error> ValidationErrors { get; set; }
    }
}

