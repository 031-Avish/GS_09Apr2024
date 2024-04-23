using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    [Serializable]
    public class DoctorNotFoundException : System.Exception
    {

        string msg;
        public DoctorNotFoundException()
        {
            msg = "Doctor does not exists";
        }

        public override string Message => msg;
    }
}