using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace DoctorAppointmentBLLibrary.Exception
{
    [Serializable]
    public class DuplicatePatientFoundException :System.Exception
    {
        string msg;
        public DuplicatePatientFoundException()
        {
            msg = "Patient already exist";
        }

        public override string Message => msg;
    }
}