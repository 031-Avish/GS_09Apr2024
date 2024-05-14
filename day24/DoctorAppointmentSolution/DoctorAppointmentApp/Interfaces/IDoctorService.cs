using DoctorAppointmentApp.Models;

namespace DoctorAppointmentApp.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality);
        public Task<Doctor> UpdateDoctorExperience(int doctorId, float experience);
        public Task<IEnumerable<Doctor>> GetAllDoctor();
    }
}
