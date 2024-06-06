using DoctorAppointmentBLLibrary;
using DoctorAppointmentBLLibrary.Exception;
using DoctorAppointmentDLLibrary;
using DoctorAppointmentModelLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentTest
{
    public class PatientBLTests
    {
        IRepository<int, Patient> repository;
        IPatientServices patientService;

        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            patientService = new PatientBL(repository);
        }

        [Test]
        public void AddPatient_Success()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1)
                , PhoneNo = "1234567890", Gender = "Male" };

            // Act
            var result = patientService.AddPatient(patient);

            // Assert
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void AddPatient_Fail()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1),
                PhoneNo = "1234567890", Gender = "Male" };
            patientService.AddPatient(patient);

            // Act & Assert
            Assert.Throws<DuplicatePatientFoundException>(() => patientService.AddPatient(patient));
        }

        [Test]
        public void DeletePatient_Success()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1),
                PhoneNo = "1234567890", Gender = "Male" };
            patientService.AddPatient(patient);

            // Act
            var result = patientService.DeletePatient(1);

            // Assert
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void DeletePatient_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<PatientDoesNotExistException>(() => patientService.DeletePatient(1));
        }

        [Test]
        public void GetAllPatients_Success()
        {
            // Arrange
            var patient1 = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1),
                PhoneNo = "1234567890", Gender = "Male" };
            var patient2 = new Patient() { Name = "Emily", DateOfBirth = new DateTime(1985, 5, 5),
                PhoneNo = "9876543210", Gender = "Female" };
            patientService.AddPatient(patient1);
            patientService.AddPatient(patient2);

            // Act
            var result = patientService.GetAllPatients();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllPatients_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<PatientDoesNotExistException>(() => patientService.GetAllPatients());
        }

        [Test]
        public void GetPatientById_Success()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1), 
                PhoneNo = "1234567890", Gender = "Male" };
            patientService.AddPatient(patient);

            // Act
            var result = patientService.GetPatientById(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPatientById_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<PatientDoesNotExistException>(() => patientService.GetPatientById(1));
        }

        [Test]
        public void UpdatePatient_Success()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1),
                PhoneNo = "1234567890", Gender = "Male" };
            patientService.AddPatient(patient);
            patient.Name = "Updated John";

            // Act
            var result = patientService.UpdatePatient(patient);

            // Assert
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void UpdatePatient_Fail()
        {
            // Arrange
            var patient = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1), 
                PhoneNo = "1234567890", Gender = "Male" };

            // Act & Assert
            Assert.Throws<PatientDoesNotExistException>(() => patientService.UpdatePatient(patient));
        }

        [Test]
        public void GetPatientByGender_Success()
        {
            // Arrange
            var patient1 = new Patient() { Name = "John", DateOfBirth = new DateTime(1980, 1, 1), 
                PhoneNo = "1234567890", Gender = "Male" };
            var patient2 = new Patient() { Name = "Emily", DateOfBirth = new DateTime(1985, 5, 5), 
                PhoneNo = "9876543210", Gender = "Female" };
            patientService.AddPatient(patient1);
            patientService.AddPatient(patient2);

            // Act
            var result = patientService.GetPatientByGender("Female");

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetPatientByGender_Fail()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<PatientDoesNotExistException>(() => patientService.GetPatientByGender("Male"));
        }
    }
}

