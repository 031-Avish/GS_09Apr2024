using System.Runtime.Serialization;

namespace PizzaAppBLLibrary
{
    [Serializable]
    public class DuplicateOrderException : Exception
    {
        string msg;
        public DuplicateOrderException()
        {
            msg = "Order ID already Exists";
        }

        public override string Message => msg;
    }
}