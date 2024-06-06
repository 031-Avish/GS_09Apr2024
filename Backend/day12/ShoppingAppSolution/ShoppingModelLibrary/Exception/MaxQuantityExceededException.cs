using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class MaxQuantityExceededException : Exception
    {
        string msg;
        public MaxQuantityExceededException()
        {
            msg = "You cannot add more then 5 item to cart";
        }

        public override string Message => msg;
    }
}