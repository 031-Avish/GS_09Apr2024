using DoctorAppointmentDLLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentDLLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly dbDoctorAppointmentContext _appointmentContext;

        public AppointmentRepository()
        {
            _appointmentContext = new dbDoctorAppointmentContext();
        }

        public Appointment Add(Appointment item)
        {
            _appointmentContext.Appointments.Add(item);
            _appointmentContext.SaveChanges();
            return item;
        }

        public Appointment Get(int key)
        {
            return _appointmentContext.Appointments.Find(key);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentContext.Appointments.ToList();
        }

        public Appointment Update(Appointment item)
        {
            Appointment existingAppointment = _appointmentContext.Appointments.Find(item.AppointmentId);

            if (existingAppointment != null)
            {
                existingAppointment.DoctorId = item.DoctorId;
                existingAppointment.PatientId = item.PatientId;
                existingAppointment.AppointmentDateAndTime = item.AppointmentDateAndTime;
                existingAppointment.Status = item.Status;

                _appointmentContext.Appointments.Update(existingAppointment);
                _appointmentContext.SaveChanges();
                return existingAppointment;
            }
            return null;
        }

        public Appointment Delete(int key)
        {
            var appointment = _appointmentContext.Appointments.Find(key);
            if (appointment != null)
            {
                _appointmentContext.Appointments.Remove(appointment);
                _appointmentContext.SaveChanges();
                return appointment;
            }
            return null;
        }
    }
}
