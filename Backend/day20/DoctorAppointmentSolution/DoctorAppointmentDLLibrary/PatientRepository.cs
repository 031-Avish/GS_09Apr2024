using DoctorAppointmentDLLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentDLLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly dbDoctorAppointmentContext _patientContext;

        public PatientRepository()
        {
            _patientContext = new dbDoctorAppointmentContext();
        }

        public Patient Add(Patient item)
        {
            _patientContext.Patients.Add(item);
            _patientContext.SaveChanges();
            return item;
        }

        public Patient Get(int key)
        {
            return _patientContext.Patients.Find(key);
        }

        public List<Patient> GetAll()
        {
            return _patientContext.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            Patient existingPatient = _patientContext.Patients.Find(item.PatientId);

            if (existingPatient != null)
            {
                existingPatient.Name = item.Name;
                existingPatient.DateOfBirth = item.DateOfBirth;
                existingPatient.PhoneNo = item.PhoneNo;
                existingPatient.Gender = item.Gender;

                _patientContext.Patients.Update(existingPatient);
                _patientContext.SaveChanges();
                return existingPatient;
            }
            return null;
        }

        public Patient Delete(int key)
        {
            var patient = _patientContext.Patients.Find(key);
            if (patient != null)
            {
                _patientContext.Patients.Remove(patient);
                _patientContext.SaveChanges();
                return patient;
            }
            return null;
        }
    }
}
