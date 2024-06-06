using System;
using System.Collections.Generic;

namespace DoctorAppointmentDLLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public double? Experience { get; set; }
        public double? Fees { get; set; }
        public bool? AvailableToday { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
