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
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        private IRepository<int, Doctor> repository;

        //public DoctorBL() {
        //    _doctorRepository = new DoctorRepository();
        //}

        public DoctorBL(IRepository<int, Doctor> repository)
        {
            _doctorRepository = repository;
        }

        public Doctor AddDoctor(Doctor doc)
        {
            
            Doctor doctor = _doctorRepository.Add(doc);
            if (doctor != null)
                return doctor;
            throw new DuplicateDoctorException();
        }

        public Doctor ChangeAvailability(Doctor doctor, bool availability)
        {
            
            doctor.AvailableToday = availability;
            Doctor doctor1= _doctorRepository.Update(doctor);
            if (doctor1 != null)
                return doctor1;
            throw new DoctorNotFoundException();
        }

        public Doctor DeleteDoctor(Doctor doctor)
        {
            Doctor deletedDoctor = _doctorRepository.Delete(doctor.DoctorId);
            if (deletedDoctor != null)
                return deletedDoctor;
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorsavailableToday()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if (doctors != null)
            {
                List<Doctor> availableDoctors = doctors.FindAll(d => d.AvailableToday);
                if (availableDoctors.Count > 0)
                {
                    return availableDoctors;
                }
            }
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorsWithSpecialization(string Specialization)
        {

            List<Doctor> doctorsWithSpecialization1 = _doctorRepository.GetAll();
            if (doctorsWithSpecialization1 != null)
            {
                List<Doctor> doctorsWithSpecialization=doctorsWithSpecialization1.FindAll(d => d.Specialization == Specialization);
                if (doctorsWithSpecialization.Count > 0)
                    return doctorsWithSpecialization;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
           
            Doctor updatedDoctor = _doctorRepository.Update(doctor);
            if (updatedDoctor != null)
                return updatedDoctor;
            throw new DoctorNotFoundException();
        }
    }
}
