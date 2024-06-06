using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    public class DepartmentDoesNotExistException : Exception
    {

        string msg;
        public DepartmentDoesNotExistException()
        {
            msg = "Department does not exists ";
        }
        public override string Message => msg;
    }
}