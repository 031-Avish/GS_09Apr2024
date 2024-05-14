using DoctorAppointmentApp.Contexts;
using DoctorAppointmentApp.Exceptions;
using DoctorAppointmentApp.Interfaces;
using DoctorAppointmentApp.Models;

namespace DoctorAppointmentApp.Services
{
    public class DoctorBasicServices: IDoctorService
    {
        private readonly IRepository<int,Doctor> _repository;
        public DoctorBasicServices(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var doctors = await _repository.GetAll();
            if (doctors.Count() <= 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string Specialization)
        {
            var doctors= await _repository.GetAll();
            if (doctors.Count() > 0)
            {
                var doctorsBySpeciality =doctors.Where(d => d.Specialization.Equals(Specialization, StringComparison.OrdinalIgnoreCase));
                if(doctorsBySpeciality.Count()>0)
                    return doctorsBySpeciality;
            }
            throw new NoSuchDoctorException();

        }

        public async Task<Doctor> UpdateDoctorExperience(int doctorId, float experience)
        {
            var doctor = await _repository.GetByKey(doctorId);
            if(doctor == null)
                throw new NotSupportedException();
            doctor.Experience = experience;
            doctor=await _repository.Update(doctor);
            return doctor;
        }
    }
}
