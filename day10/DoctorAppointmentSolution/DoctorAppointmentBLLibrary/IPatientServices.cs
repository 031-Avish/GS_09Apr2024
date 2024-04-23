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
        int AddPatient(Patient patient);
        
        Patient GetPatientById(int id); 
        List<Patient> GetAllPatients();

        int UpdatePatient(Patient patient);
        bool DeletePatient(int id);

        List<Patient> GetPatientByGender(string gender);
    }
}
