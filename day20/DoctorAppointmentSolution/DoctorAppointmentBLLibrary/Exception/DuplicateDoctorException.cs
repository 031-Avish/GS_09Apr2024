using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    public class DuplicateDoctorException : System.Exception
    {

        string msg;
        public DuplicateDoctorException()
        {
            msg = "Doctor Already Exists";
        }

        public override string Message => msg;
    }
}