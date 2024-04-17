using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorAppointmentModelLibrary
{
    public class Appointment
    {
        public int AppointmentId {  get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentDateAndTime {  get; set; }
        public string Status {  get; set; }
        public Appointment()
        {
            AppointmentId = 0;
            Doctor = new Doctor();
            Patient = new Patient();
            AppointmentDateAndTime = DateTime.Now;
            Status = string.Empty;
        }

        public Appointment(int appointmentId, Doctor doctor, Patient patient, DateTime appointmentDateAndTime)
        {
            AppointmentId = appointmentId;
            Doctor = doctor;
            Patient = patient;
            AppointmentDateAndTime = appointmentDateAndTime;
            Status = "Scheduled";
        }
        public virtual void PrintDoctorDetails()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Appointment's Id " + AppointmentId);
            Console.WriteLine("Doctor Name " + Doctor.Name);
            Console.WriteLine("Patient's Name " + Patient.Name);
            Console.WriteLine("Appoint's Date and Time " + AppointmentDateAndTime );
            Console.WriteLine("Appointmet Status " +  Status);
        }

        public override bool Equals(object? obj)
        {
            return this.AppointmentId.Equals((obj as Appointment).AppointmentId);
        }
        public override string ToString()
        {
            return "Appointment's Id " + AppointmentId +
            "Doctor Name " + Doctor.Name +
            "Patient's Name " + Patient.Name +
            "Appoint's Date and Time " + AppointmentDateAndTime +
           "Appointmet Status ";
        }
    }
}
