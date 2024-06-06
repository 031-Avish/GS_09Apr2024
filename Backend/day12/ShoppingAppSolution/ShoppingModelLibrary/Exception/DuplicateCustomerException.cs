using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    public class DuplicateCustomerException : Exception
    {
        string msg;
        public DuplicateCustomerException()
        {
            msg = "Duplicate Customer ! Already exists";
        }
        public override string Message => msg;
    }
}