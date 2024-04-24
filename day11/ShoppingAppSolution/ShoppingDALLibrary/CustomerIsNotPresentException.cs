using System.Runtime.Serialization;

namespace ShoppingDALLibrary
{
    public class CustomerIsNotPresentException : Exception
    {
        string msg;
        public CustomerIsNotPresentException()
        {
            msg = "There is no customer present !! Please add first";
        }
        public override string Message => msg;
    }
}