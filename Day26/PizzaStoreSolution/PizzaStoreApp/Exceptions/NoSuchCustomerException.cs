using System.Runtime.Serialization;

namespace EmployeeRequestTrackerApp.Exceptions
{
    public class NoSuchCustomerException : Exception
    {
        string msg;
        public NoSuchCustomerException()
        {
            msg = "No such Customer is found";
        }
        public override string Message => msg;

    }
}