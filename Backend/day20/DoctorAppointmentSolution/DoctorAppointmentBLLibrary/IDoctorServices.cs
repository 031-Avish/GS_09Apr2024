//using DoctorAppointmentModelLibrary;
using DoctorAppointmentDLLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IDoctorServices
    {
        Doctor AddDoctor(Doctor doctor);

        Doctor UpdateDoctor(Doctor doctor);

        Doctor DeleteDoctor(Doctor doctor);

        Doctor ChangeAvailability(Doctor doctor, bool availability);
        List<Doctor> GetDoctorsWithSpecialization(string Speciatization);
        List<Doctor> GetDoctorsavailableToday();

    }
}
