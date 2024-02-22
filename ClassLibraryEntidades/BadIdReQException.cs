using System.Runtime.Serialization;

namespace ClassLibraryEntidades
{
    [Serializable]
    public class BadIdReQException : Exception
    {

        public BadIdReQException()
        {
        }

        public BadIdReQException(string? message) : base(message)
        {
        }

        public BadIdReQException(string? message, Exception? innerException) : base(message, innerException)
        {
           
        }

        protected BadIdReQException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}