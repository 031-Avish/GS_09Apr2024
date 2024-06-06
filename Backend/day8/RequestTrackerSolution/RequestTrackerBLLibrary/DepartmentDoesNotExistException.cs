using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    internal class DepartmentDoesNotExistException : Exception
    {

        string msg;
        public DepartmentDoesNotExistException()
        {
            msg = "Department does not exists ";
        }
        public override string Message => msg;
    }
}