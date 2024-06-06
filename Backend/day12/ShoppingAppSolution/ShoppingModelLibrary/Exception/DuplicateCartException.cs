using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class DuplicateCartException : Exception
    {
        string msg;
        public DuplicateCartException()
        {
            msg = "Duplicate Cart ! Cart Already exists";
        }
        public override string Message => msg;

    }
}