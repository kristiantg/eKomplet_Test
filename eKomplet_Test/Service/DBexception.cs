using System;
using System.Runtime.Serialization;

namespace eKomplet_Test.Service
{
    [Serializable]
    internal class DBexception : Exception
    {
        public DBexception()
        {
        }

        public DBexception(int errorCode)
            : base(errorCode.ToString())
        {
        }

        public DBexception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DBexception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}