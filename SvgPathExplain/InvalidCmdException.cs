using System;

namespace SVGPath
{
    [Serializable]
    public class InvalidCmdException : Exception
    {
        public int Index { get; set; }

        public InvalidCmdException() { }
        public InvalidCmdException(string message) : base(message) { }
        public InvalidCmdException(string message, int index) : base(message) { Index = index; }
        public InvalidCmdException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCmdException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
