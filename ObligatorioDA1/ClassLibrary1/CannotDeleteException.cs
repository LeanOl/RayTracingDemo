using System;
namespace Exceptions
{
    public class CannotDeleteException : Exception
    {
        public CannotDeleteException() { }

        public CannotDeleteException(string message)
            : base(message) { }

        public CannotDeleteException(string message, Exception inner)
            : base(message, inner) { }
    }
}
