using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IPatientServices
    {
        Patient AddPatient(Patient patient);
        
        Patient GetPatientById(int id); 
        List<Patient> GetAllPatients();

        Patient UpdatePatient(Patient patient);
        Patient DeletePatient(int id);

        List<Patient> GetPatientByGender(string gender);
    }
}
