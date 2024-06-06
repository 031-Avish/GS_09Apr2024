using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    internal class EmployeeDoesNotExistException : Exception
    {
        
            string msg;
            public EmployeeDoesNotExistException()
            {
                msg = "Employee does not exists ";
            }
        public override string Message => msg;
    }
}