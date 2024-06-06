using System.Runtime.Serialization;

namespace DoctorAppointmentApp.Exceptions
{
    public class NoSuchDoctorException : Exception
    {
        string msg;
        public NoSuchDoctorException()
        {
            msg = "No such Doctor is found";
        }
        public override string Message => msg;

    }
}