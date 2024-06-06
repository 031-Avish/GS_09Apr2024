using DoctorAppointmentBLLibrary;
using DoctorAppointmentBLLibrary.Exception;
using DoctorAppointmentDLLibrary;
using DoctorAppointmentDLLibrary.Model;

//using DoctorAppointmentModelLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentTest
{
    public class AppointmentBLTests
    {
        IRepository<int, Appointment> repository;
        IAppointmentServices appointmentService;

        [SetUp]
        public void Setup()
        {
            repository = new AppointmentRepository();
            appointmentService = new AppointmentBL(repository);
        }

        [Test]
        public void ScheduleAppointment_Success()
        {
            // Arrange
            var appointment = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), 
                AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };

            // Act
            var result = appointmentService.ScheduleAppointment(appointment);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ScheduleAppointment_Fail_PastDate()
        {
            // Arrange
            var appointment = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(-1), Status = "Scheduled" };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => appointmentService.ScheduleAppointment(appointment));
        }

        [Test]
        public void GetAllAppointments_Success()
        {
            // Arrange
            var appointment1 = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            var appointment2 = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(2), Status = "Scheduled" };
            appointmentService.ScheduleAppointment(appointment1);
            appointmentService.ScheduleAppointment(appointment2);

            // Act
            var result = appointmentService.GetAllAppointments();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllAppointments_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.GetAllAppointments());
        }

        [Test]
        public void CancelAppointment_Success()
        {
            // Arrange
            var appointment = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            appointmentService.ScheduleAppointment(appointment);

            // Act
            var result = appointmentService.CancelAppointment(1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CancelAppointment_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.CancelAppointment(1));
        }

        [Test]
        public void RescheduleAppointment_Success()
        {
            // Arrange
            var appointment = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            appointmentService.ScheduleAppointment(appointment);

            // Act
            var result = appointmentService.RescheduleAppointment(1, DateTime.Now.AddDays(2));

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RescheduleAppointment_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.RescheduleAppointment(1, DateTime.Now.AddDays(2)));
        }

        [Test]
        public void GetAppointmentsForDoctor_Success()
        {
            // Arrange
            var appointment1 = new Appointment() { Doctor = new Doctor() { DoctorId = 1 }, Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            var appointment2 = new Appointment() { Doctor = new Doctor() { DoctorId = 2 }, Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(2), Status = "Scheduled" };
            appointmentService.ScheduleAppointment(appointment1);
            appointmentService.ScheduleAppointment(appointment2);

            // Act
            var result = appointmentService.GetAppointmentsForDoctor(1);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAppointmentsForDoctor_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.GetAppointmentsForDoctor(1));
        }

        [Test]
        public void GetAppointmentsForPatient_Success()
        {
            // Arrange
            var appointment1 = new Appointment() { Doctor = new Doctor(), Patient = new Patient() { PatientId = 1 }, AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            var appointment2 = new Appointment() { Doctor = new Doctor(), Patient = new Patient() { PatientId = 2 }, AppointmentDateAndTime = DateTime.Now.AddDays(2), Status = "Scheduled" };
            appointmentService.ScheduleAppointment(appointment1);
            appointmentService.ScheduleAppointment(appointment2);

            // Act
            var result = appointmentService.GetAppointmentsForPatient(1);

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAppointmentsForPatient_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.GetAppointmentsForPatient(1));
        }

        [Test]
        public void GetAppointmentsByStatus_Success()
        {
            // Arrange
            var appointment1 = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(1), Status = "Scheduled" };
            var appointment2 = new Appointment() { Doctor = new Doctor(), Patient = new Patient(), AppointmentDateAndTime = DateTime.Now.AddDays(2), Status = "Cancelled" };
            appointmentService.ScheduleAppointment(appointment1);
            appointmentService.ScheduleAppointment(appointment2);

            // Act
            var result = appointmentService.GetAppointmentsByStatus("Cancelled");

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAppointmentsByStatus_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<AppointmentDoesNotExistException>(() => appointmentService.GetAppointmentsByStatus("Cancelled"));
        }
    }
}
