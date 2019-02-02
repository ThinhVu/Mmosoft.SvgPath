using System;

namespace SVGPath
{
    [Serializable]
    public class InvalidSvgCharacterException : Exception
    {
        public InvalidSvgCharacterException() { }
        public InvalidSvgCharacterException(string message) : base(message) { }
        public InvalidSvgCharacterException(string message, Exception inner) : base(message, inner) { }
        protected InvalidSvgCharacterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
