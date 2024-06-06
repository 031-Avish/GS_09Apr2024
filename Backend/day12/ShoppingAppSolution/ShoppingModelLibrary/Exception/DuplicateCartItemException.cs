using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    
    public class DuplicateCartItemException : Exception
    {
        string msg;
        public DuplicateCartItemException()
        {
            msg = "Duplicate Cart item ! Already exists";
        }
        public override string Message => msg;
    }
}