using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class CustomerIdNotPresentException : Exception
    {
        string msg;
        public CustomerIdNotPresentException()
        {
            msg = "Customer Id is not found in CartItem Object";
        }
    }
}