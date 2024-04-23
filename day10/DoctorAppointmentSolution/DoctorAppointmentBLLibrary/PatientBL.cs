using DoctorAppointmentBLLibrary.Exception;
using DoctorAppointmentDLLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class PatientBL : IPatientServices
    {
        readonly IRepository<int, Patient> _patientRepository;
        public int AddPatient(Patient patient)
        {
            Patient addedPatient = _patientRepository.Add(patient);

            if (addedPatient != null)
                return addedPatient.PatientId;
            throw new DuplicatePatientFoundException();
        }

        public int DeletePatient(Patient patient)
        {
            Patient deletedPatient = _patientRepository.Delete(patient.PatientId);
            if (deletedPatient != null)
                return deletedPatient.PatientId;
            throw new PatientDoesNotExistException();
        }



        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientRepository.GetAll();
            if (patients != null)
                return patients;
            throw new PatientDoesNotExistException();
        }



        public Patient GetPatientById(int patientId)
        {

            Patient patient = _patientRepository.Get(patientId);
            if (patient != null)
                return patient;
            throw new PatientDoesNotExistException();
        }

        public int UpdatePatient(Patient patient)
        {

            Patient updatedPatient = _patientRepository.Update(patient);
            if (updatedPatient != null)
                return updatedPatient.PatientId;
            throw new PatientDoesNotExistException();
        }

        public List<Patient> GetPatientByGender(string gender)
        {
            List<Patient> allPatients = _patientRepository.GetAll();
            if (allPatients != null)
            {
                List<Patient> patientsByGender = allPatients.FindAll(p => p.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));

                return patientsByGender;
            }
            throw new PatientDoesNotExistException();
        }
    }
}
