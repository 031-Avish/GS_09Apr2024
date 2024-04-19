using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    public class DuplicateEmployeeIdException : Exception
    {
        string msg;
        public DuplicateEmployeeIdException()
        {
            msg = "Employee I already exists";
        }
        public override string Message => msg;
    }
}