using System.Runtime.Serialization;

namespace EmployeeRequestTrackerApp.Exceptions
{
    public class NoCustomerFoundException : Exception
    {
        string msg;
        public NoCustomerFoundException()
        {
            msg = "There is not any Customer present";
        }
        public override string Message => msg;
    }
}