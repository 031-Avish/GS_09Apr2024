using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class CartIdNotPresentException : Exception
    {
        string msg;
        public CartIdNotPresentException()
        {
            msg = "Customer Id is not found in CartItem Object";
        }
    }
}