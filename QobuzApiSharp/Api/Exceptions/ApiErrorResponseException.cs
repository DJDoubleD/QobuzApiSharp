using QobuzApiSharp.Models;
using System;
using System.Runtime.Serialization;

namespace QobuzApiSharp.Exceptions
{
    [Serializable]
    public class ApiErrorResponseException : Exception
    {
        public string RequestContent { get; }
        public string ResponseStatusCode { get; }
        public string ResponseStatus { get; }
        public string ResponseReason { get; }

        public ApiErrorResponseException()
        {
        }

        public ApiErrorResponseException(string message) : base(message)
        {
        }

        public ApiErrorResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiErrorResponseException(string message, string requestContent, QobuzApiStatusResponse errorResponse)
            : base(message)
        {
            this.RequestContent = requestContent;
            this.ResponseStatusCode = errorResponse.Code;
            this.ResponseStatus = errorResponse.Status;
            this.ResponseReason = errorResponse.Message;
        }

        public ApiErrorResponseException(string message, string requestContent, QobuzApiStatusResponse errorResponse, Exception innerException)
            : base(message, innerException)
        {
            RequestContent = requestContent;
            ResponseStatusCode = errorResponse.Code;
            ResponseStatus = errorResponse.Status;
            ResponseReason = errorResponse.Message;
        }

        protected ApiErrorResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            RequestContent = info.GetString("ResponseContent");
            ResponseStatusCode = info.GetString("ResponseStatusCode");
            ResponseStatus = info.GetString("ResponseStatus");
            ResponseReason = info.GetString("ResponseReason");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ResponseContent", RequestContent);
            info.AddValue("ResponseStatusCode", ResponseStatusCode);
            info.AddValue("ResponseStatus", ResponseStatus);
            info.AddValue("ResponseReason", ResponseReason);
        }
    }
}