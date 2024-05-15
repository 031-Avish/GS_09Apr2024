using DoctorAppointmentApp.Models;

namespace DoctorAppointmentApp.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string Specialization);
        public Task<Doctor> UpdateDoctorExperience(int doctorId, float experience);
        public Task<IEnumerable<Doctor>> GetAllDoctor();
        public Task<Doctor> AddDoctor(Doctor doctor);

    }
}
