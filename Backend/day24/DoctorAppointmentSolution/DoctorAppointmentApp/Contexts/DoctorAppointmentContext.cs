using DoctorAppointmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApp.Contexts
{
    public class DoctorAppointmentContext : DbContext
    {
        public DoctorAppointmentContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                 new Doctor() {DoctorID=101, DoctorName= "Ramu" , Experience=5.5f, Specialization="Heart" , Available=true},
                 new Doctor() { DoctorID = 102, DoctorName = "Samu", Experience = 8.5f, Specialization = "Skin", Available = true },
                 new Doctor() { DoctorID = 103, DoctorName = "Kamu", Experience = 2, Specialization = "Eye", Available = true },
                 new Doctor() { DoctorID = 104, DoctorName = "Tamu", Experience = 7, Specialization = "Heart", Available = true }
                 );
        }
    }
}
