using System;
using System.Runtime.Serialization;

namespace SimpleGoogleFitApi.Common
{
    [Serializable]
    internal class MissingScopeException : Exception
    {
        public MissingScopeException()
        {
        }

        public MissingScopeException(string? message) : base(message)
        {
        }

        public MissingScopeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MissingScopeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}