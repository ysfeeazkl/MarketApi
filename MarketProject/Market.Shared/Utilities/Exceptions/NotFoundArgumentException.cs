using Fahax.Shared.Entities.Concrete;

namespace Fahax.Shared.Utilities.Exceptions
{
    public class NotFoundArgumentException : Exception
    {
        public NotFoundArgumentException(string message, string errorMessage, string propertyName) : base(message)
        {
        }
        public NotFoundArgumentException(string message, string propertyName) : base(message)
        {
        }
        public NotFoundArgumentException(string message, Error validationError) : base(message)
        {
            ValidationError = validationError;
        }
        public NotFoundArgumentException(string message) : base(message)
        {
        }
        public Error ValidationError { get; set; }
    }
}

