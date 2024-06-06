using System.Runtime.Serialization;

namespace DoctorAppointmentApp.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        string msg;
        public NoDoctorsFoundException()
        {
            msg = "There is not any Doctor present";
        }
        public override string Message => msg;
    }
}