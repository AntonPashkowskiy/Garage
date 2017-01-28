using System;

namespace Garage.Core.Exceptions
{
    public class UnexpectedNullException : Exception
    {
        public UnexpectedNullException() { }
        public UnexpectedNullException(string message) : base(message) { }
        public UnexpectedNullException(string message, Exception inner) : base(message, inner) { }
    }
}
