using System.Runtime.Serialization;

namespace PizzaAppBLLibrary
{
    [Serializable]
    public class OrderDoesNotExistException : Exception
    {
        string msg;
        public OrderDoesNotExistException()
        {
            msg = "Order Does Not Exists";
        }
        public override string Message => msg;
    }
}