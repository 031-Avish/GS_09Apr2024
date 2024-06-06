//using DoctorAppointmentModelLibrary;
using DoctorAppointmentDLLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IAppointmentServices
    {
        int ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        int CancelAppointment(int id);
        int RescheduleAppointment(int id, DateTime newDateTime);

        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        List<Appointment> GetAppointmentsByStatus(string status);
    }
}
