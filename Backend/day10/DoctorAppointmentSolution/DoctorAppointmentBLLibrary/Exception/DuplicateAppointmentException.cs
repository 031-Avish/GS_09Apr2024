using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    
    public class DuplicateAppointmentException : System.Exception
    {

        string msg;
        public DuplicateAppointmentException()
        {
            msg = "Appointment Already Exists";
        }

        public override string Message => msg;
    }
}