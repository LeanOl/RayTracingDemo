namespace Exceptions
{
    public class ElementAlreadyExistsException : Exception
    {
        public ElementAlreadyExistsException() { }

        public ElementAlreadyExistsException(string message)
            : base(message) { }

        public ElementAlreadyExistsException(string message, Exception inner)
            : base(message, inner) { }
    }
}