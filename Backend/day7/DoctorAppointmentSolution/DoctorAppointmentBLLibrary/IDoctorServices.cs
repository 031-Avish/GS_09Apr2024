using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IDoctorServices
    {
        int AddDoctor(Doctor doctor);

        int UpdateDoctor(Doctor doctor);

        int DeleteDoctor(Doctor doctor);

        Doctor ChangeAvailability(Doctor doctor, bool availability);
        List<Doctor> GetDoctorsWithSpecialization(string Speciatization);
        List<Doctor> GetDoctorsavailableToday();

    }
}
