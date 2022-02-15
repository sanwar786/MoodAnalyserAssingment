using System;
using System.Runtime.Serialization;

namespace MoodAnalyser
{
    [Serializable]
    internal class MoodAnalyserException : Exception
    {
        private object eMPTY_EXCEPTION;
        private string v;

        public MoodAnalyserException()
        {
        }

        public MoodAnalyserException(string message) : base(message)
        {
        }

        public MoodAnalyserException(object eMPTY_EXCEPTION, string v)
        {
            this.eMPTY_EXCEPTION = eMPTY_EXCEPTION;
            this.v = v;
        }

        public MoodAnalyserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MoodAnalyserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static object ExceptionType { get; internal set; }
    }
}