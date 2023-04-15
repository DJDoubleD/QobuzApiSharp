using System;
using System.Runtime.Serialization;

namespace QobuzApiSharp.Exceptions
{
    [Serializable]
    public class ApiResponseParseErrorException : Exception
    {
        public string ResponseContent { get; }

        public ApiResponseParseErrorException()
        {
        }

        public ApiResponseParseErrorException(string message) : base(message)
        {
        }

        public ApiResponseParseErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiResponseParseErrorException(string message, string requestContent)
            : base(message)
        {
            ResponseContent = requestContent;
        }

        public ApiResponseParseErrorException(string message, string requestContent, Exception innerException)
            : base(message, innerException)
        {
            ResponseContent = requestContent;
        }

        protected ApiResponseParseErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResponseContent = info.GetString("ResponseContent");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ResponseContent", ResponseContent);
        }
    }
}