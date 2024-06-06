using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class CartIsEmptyException : Exception
    {
        string msg;
        public CartIsEmptyException()
        {
            msg = "Cart is empty";
        }
        public override string Message => msg;

    }
}