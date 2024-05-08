using DoctorAppointmentDLLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDLLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        //readonly Dictionary<int, Doctor> _doctors;
        dbDoctorAppointmentContext _doctorContext;
        public DoctorRepository()
        {
            _doctorContext = new dbDoctorAppointmentContext();
        }

        public Doctor Add(Doctor item)
        {
            _doctorContext.Doctors.Add(item);
            _doctorContext.SaveChanges();
            return item;
        }

        public Doctor Get(int key)
        {
            return _doctorContext.Doctors.Find(key);
        }

        public List<Doctor> GetAll()
        {
            if(_doctorContext.Doctors == null)
                return null;
            return _doctorContext.Doctors.ToList();
        }

        public Doctor Update(Doctor item)
        {
            Doctor existingDoctor= _doctorContext.Doctors.Find(item.DoctorId);
            
            if(existingDoctor != null)
            {
                existingDoctor.Name = item.Name;
                existingDoctor.Specialization = item.Specialization;
                existingDoctor.Experience = item.Experience;
                existingDoctor.Fees = item.Fees;
                existingDoctor.AvailableToday = item.AvailableToday;
                
                _doctorContext.Doctors.Update(existingDoctor);
                _doctorContext.SaveChanges();
                return existingDoctor;
            }
            return null;
        }

        public Doctor Delete(int key)
        {
            var doctor=_doctorContext.Doctors.Find(key);
            if (doctor != null)
            {
                _doctorContext.Doctors.Remove(doctor);
                _doctorContext.SaveChanges();
                return doctor;
            }
            return null;
        }


    }
}
