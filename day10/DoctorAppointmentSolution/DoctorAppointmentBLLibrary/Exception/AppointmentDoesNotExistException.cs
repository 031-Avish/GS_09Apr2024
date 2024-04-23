using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    public class AppointmentDoesNotExistException : System.Exception
    {

        string msg;
        public AppointmentDoesNotExistException()
        {
            msg = "Appoitment is not found";
        }

        public override string Message => msg;
    }
}
