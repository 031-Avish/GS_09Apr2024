using System.Runtime.Serialization;

namespace PizzaAppBLLibrary
{
    [Serializable]
    public class PizzaDoesNotExistException : Exception
    {
        string msg;
        public PizzaDoesNotExistException()
        {
            msg = "Pizza does not exists";
        }
        public override string Message => msg;

    }
}