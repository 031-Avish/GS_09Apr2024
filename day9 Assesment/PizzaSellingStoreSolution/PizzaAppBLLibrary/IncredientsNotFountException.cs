using System.Runtime.Serialization;

namespace PizzaAppBLLibrary
{
    [Serializable]
    public class IncredientsNotFountException : Exception
    {
        string msg;
        public IncredientsNotFountException()
        {
            msg = "Incredient is not found";
        }

        public override string Message => msg;

    }
}