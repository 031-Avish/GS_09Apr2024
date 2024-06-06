using System;
using System.Collections.Generic;

namespace DoctorAppointmentDLLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNo { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
