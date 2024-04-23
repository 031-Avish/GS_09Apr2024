using DoctorAppointmentDLLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBL() {
            _doctorRepository = new DoctorRepository();
        }
        public int AddDoctor(Doctor doc)
        {
            
            Doctor doctor = _doctorRepository.Add(doc);
            if (doctor != null)
                return doctor.DoctorId;
            else
                throw new DuplicateDoctorException();
        }

        public Doctor ChangeAvailability(Doctor doctor, bool availability)
        {
            
            doctor.AvailableToday = availability;
            Doctor doctor1= _doctorRepository.Update(doctor);
            if (doctor1 != null)
                return doctor1;
            throw DoctorNotFoundException();
        }

        public int DeleteDoctor(Doctor doctor)
        {
            Doctor deletedDoctor = _doctorRepository.Delete(doctor.DoctorId);
            if (deletedDoctor != null)
                return deletedDoctor.DoctorId;
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorsavailableToday()
        {
            List<Doctor> availableDoctors = _doctorRepository.GetAll().FindAll(d => d.AvailableToday);
            if (availableDoctors.Count > 0)
                return availableDoctors;

            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorsWithSpecialization(string Specialization)
        {

            List<Doctor> doctorsWithSpecialization = _doctorRepository.GetAll().FindAll(d => d.Specialization == Specialization);

            if (doctorsWithSpecialization.Count > 0)
                return doctorsWithSpecialization;
            throw new DoctorNotFoundException();
        }

        public int UpdateDoctor(Doctor doctor)
        {
           
            Doctor updatedDoctor = _doctorRepository.Update(doctor);
            if (updatedDoctor != null)
                return updatedDoctor.DoctorId;
            throw new DoctorNotFoundException();
        }
    }
}
