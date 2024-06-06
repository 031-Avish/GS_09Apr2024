namespace DoctorAppointmentApp.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public float Experience { get; set; } 
        public string Specialization { get; set; } = string.Empty;

        public bool Available { get; set; }

        public Doctor()
        {
            DoctorID = 0;
            DoctorName = string.Empty;
            Specialization = string.Empty;
            Available = true;
        }

        public Doctor(int doctorID, string doctorName, string specialization, bool available,float experience)
        {
            DoctorID = doctorID;
            DoctorName = doctorName;
            Specialization = specialization;
            Available = available;
            Experience = experience;

        }
    }
}
