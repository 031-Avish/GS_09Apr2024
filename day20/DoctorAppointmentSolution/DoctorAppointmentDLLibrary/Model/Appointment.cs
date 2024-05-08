using System;
using System.Collections.Generic;

namespace DoctorAppointmentDLLibrary.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? AppointmentDateAndTime { get; set; }
        public string? Status { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
