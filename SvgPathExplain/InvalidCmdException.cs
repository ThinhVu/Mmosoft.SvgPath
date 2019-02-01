using System;

namespace SVGPathExplain
{
    [Serializable]
    public class InvalidCmdException : Exception
    {
        public InvalidCmdException() { }
        public InvalidCmdException(string message) : base(message) { }
        public InvalidCmdException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCmdException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
