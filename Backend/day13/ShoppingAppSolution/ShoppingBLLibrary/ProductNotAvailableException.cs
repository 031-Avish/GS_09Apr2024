using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class ProductNotAvailableException : Exception
    {
        public ProductNotAvailableException()
        {
        }

        public ProductNotAvailableException(string? message) : base(message)
        {
        }

        public ProductNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}