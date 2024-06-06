using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class NoCartWithGivenIdException : Exception
    {
        string msg;
        public NoCartWithGivenIdException()
        {
            msg = "No card is present";
        }

        public override string Message => msg;
    }
}