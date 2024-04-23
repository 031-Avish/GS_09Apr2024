using DoctorAppointmentDLLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentBLLibrary
{
    public class AppointmentBL : IAppointmentServices
    {
        readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentBL()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public int ScheduleAppointment(Appointment appointment)
        {
        
            if (appointment.AppointmentDateAndTime < DateTime.Now)
                throw new InvalidOperationException("Appointment date must be in the future.");

            var addedAppointment = _appointmentRepository.Add(appointment);
            if (addedAppointment != null)
                return addedAppointment.AppointmentId;
            
            throw new DuplicateAppointmentException();

        }

        public List<Appointment> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAll();
            if (appointments != null)
                return appointments;
            
            throw new AppointmentDoesNotExistException();

        }

        public int CancelAppointment(int id)
        {
            var appointmentToDelete = _appointmentRepository.Get(id);
            if (appointmentToDelete != null)
            {
                _appointmentRepository.Delete(id);
                return id;
            }
            throw new AppointmentDoesNotExistException();

        }

        public int RescheduleAppointment(int id, DateTime newDateTime)
        {
            var appointmentToReschedule = _appointmentRepository.Get(id);
            if (appointmentToReschedule != null)
            { 
                appointmentToReschedule.AppointmentDateAndTime = newDateTime;
                _appointmentRepository.Update(appointmentToReschedule);
                return id;
            }
            throw new AppointmentDoesNotExistException();
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = _appointmentRepository.GetAll()?.Where(a => a.Doctor.DoctorId == doctorId).ToList();
            if (appointments != null)
                return appointments;
            throw new AppointmentDoesNotExistException();
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var appointments = _appointmentRepository.GetAll()?.Where(a => a.Patient.PatientId == patientId).ToList();
            if (appointments != null)
                return appointments;
            throw new AppointmentDoesNotExistException();
        }

        public List<Appointment> GetAppointmentsByStatus(string status)
        {
            var appointments = _appointmentRepository.GetAll()?.Where(a => a.Status == status).ToList();
            if (appointments != null)
                return appointments;
            throw new AppointmentDoesNotExistException();

        }
    }
}

