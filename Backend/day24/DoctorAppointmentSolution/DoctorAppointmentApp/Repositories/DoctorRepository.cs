using DoctorAppointmentApp.Contexts;
using DoctorAppointmentApp.Exceptions;
using DoctorAppointmentApp.Interfaces;
using DoctorAppointmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApp.Repositories
{
    public class DoctorRepository : IRepository<int,Doctor>
    {
        private readonly DoctorAppointmentContext _context;
        public DoctorRepository(DoctorAppointmentContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> DeleteByKey(int key)
        {
            var doctor= await GetByKey(key);
            if (doctor != null)
            {
                _context.Remove(doctor);
                await _context.SaveChangesAsync();
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> GetByKey(int key)
        {
            var doctor =await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorID == key);
            return doctor;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor=await GetByKey(item.DoctorID);
            if (doctor != null)
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
    }
}
