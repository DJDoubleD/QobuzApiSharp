using System;
using System.Runtime.Serialization;

namespace QobuzApiSharp.Exceptions
{
    [Serializable]
    public class QobuzApiInitializationException : Exception
    {
        public QobuzApiInitializationException() { }

        public QobuzApiInitializationException(string message) : base(message) { }

        public QobuzApiInitializationException(string message, Exception innerException) : base(message, innerException) { }

        protected QobuzApiInitializationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}