using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IAppointmentServices
    {
        bool ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        bool CancelAppointment(int id);
        bool RescheduleAppointment(int id, DateTime newDateTime);

        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        List<Appointment> GetAppointmentsByStatus(Appointment status);
    }
}
