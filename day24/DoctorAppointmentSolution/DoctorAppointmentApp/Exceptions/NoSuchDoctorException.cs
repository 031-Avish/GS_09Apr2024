using System.Runtime.Serialization;

namespace DoctorAppointmentApp.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string msg;
        public NoSuchEmployeeException()
        {
            msg = "No such Employee is found";
        }
        public override string Message => msg;

    }
}