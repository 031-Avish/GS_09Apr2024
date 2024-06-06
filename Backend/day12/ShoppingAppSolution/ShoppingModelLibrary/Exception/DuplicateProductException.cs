using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class DuplicateProductException : Exception
    {
        string msg;
        public DuplicateProductException()
        {
            msg = "Duplicate Product ! Already exists";
        }
        public override string Message => msg;
    }
}