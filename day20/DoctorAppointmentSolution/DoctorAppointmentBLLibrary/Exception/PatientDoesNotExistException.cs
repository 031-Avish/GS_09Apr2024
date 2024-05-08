using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    public class PatientDoesNotExistException : System.Exception
    {
        string msg;
        public PatientDoesNotExistException()
        {
            msg = "Patient is not found";
        }

        public override string Message => msg;
    }
}