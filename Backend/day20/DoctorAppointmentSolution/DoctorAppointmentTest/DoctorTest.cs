using DoctorAppointmentBLLibrary;
using DoctorAppointmentBLLibrary.Exception;
using DoctorAppointmentDLLibrary;
using DoctorAppointmentDLLibrary.Model;
//using DoctorAppointmentModelLibrary;

namespace DoctorAppointmentTest
{
    public class Tests
    {
        IRepository<int,Doctor> repository;
        IDoctorServices doctorService;
        [SetUp]
        public void Setup()
        {
            repository=new DoctorRepository();
            
            doctorService=new DoctorBL(repository);
        }

        [Test]
        public void AddSuccessTest()
        {
            Doctor doctor = new Doctor() { Name = "Varun", Specialization = "Cardiologist",
                Experience = 5, Fees = 300, AvailableToday = true };
            var result = doctorService.AddDoctor(doctor);
            Assert.AreEqual(1, result.DoctorId);
        }

        [Test]
        public void ChangeAvailability_Success()
        {
            // Arrange
            var doctorToUpdate = new Doctor()
            {
                Name = "John",
                Specialization = "Dentist",
                Experience = 10,
                Fees = 200,
                AvailableToday = true
            };
            var res = doctorService.AddDoctor(doctorToUpdate);
            // Act
            var result = doctorService.ChangeAvailability(res, false);

            // Assert
            Assert.AreEqual(false, result.AvailableToday);
        }

        [Test]
        public void ChangeAvailability_FailExc()
        {
            // Arrange
            var doctorToUpdate = new Doctor()
            {
                DoctorId =  89,
                Name = "Emily",
                Specialization = "Pediatrician",
                Experience = 8,
                Fees = 250,
                AvailableToday = true
            };

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.ChangeAvailability(doctorToUpdate, true));
        }


        [Test]
        public void DeleteDoctor_Success()
        {
            // Arrange
            var doctorToDelete = new Doctor()
            {
                
                Name = "John",
                Specialization = "Dentist",
                Experience = 10,
                Fees = 200,
                AvailableToday = true
            };
            var res= doctorService.AddDoctor(doctorToDelete);

            // Act
            var result = doctorService.DeleteDoctor(res);

            // Assert
            Assert.AreEqual(res.DoctorId, result.DoctorId);
        }

        [Test]
        public void DeleteDoctor_Fail()
        {
            // Arrange
            var doctorToDelete = new Doctor()
            {
                DoctorId = 101,
                Name = "Emily",
                Specialization = "Pediatrician",
                Experience = 8,
                Fees = 250,
                AvailableToday = true
            };

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.DeleteDoctor(doctorToDelete));
        }

        [Test]
        public void GetDoctorsavailableToday_Success()
        {
            // Arrange
            var availableDoctors = new List<Doctor>()
            {
                new Doctor() { Name = "John", Specialization = "Dentist", Experience = 10,
                    Fees = 200, AvailableToday = true },
                new Doctor() { Name = "Emily", Specialization = "Pediatrician",
                    Experience = 8, Fees = 250, AvailableToday = true }
            };
            foreach (var doctor in availableDoctors)
            {
                doctorService.AddDoctor(doctor);
            }

            // Act
            var result = doctorService.GetDoctorsavailableToday();

            // Assert
            Assert.AreEqual(availableDoctors, result);
        }

        [Test]
        public void GetDoctorsavailableToday_Fail()
        {
            // Arrange
            var availableDoctors = new List<Doctor>(); // Empty list

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorsavailableToday());
        }
        [Test]
        public void GetDoctorsavailableToday_FailExc()
        {
            // Arrange
            var doctors = new Doctor()
            {
                Name = "John",
                Specialization = "Dentist",
                Experience = 10,
                Fees = 200,
                AvailableToday = false,
            };

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorsavailableToday());
        }

        [Test]
        public void GetDoctorsWithSpecialization_Success()
        {
            // Arrange
            var specialization = "Pediatrician";
            var doctorsWithSpecialization = new List<Doctor>()
            {
            new Doctor() { Name = "John", Specialization = specialization,
            Experience = 10, Fees = 200, AvailableToday = true },
            new Doctor() { Name = "Emily", Specialization = specialization,
            Experience = 8, Fees = 250, AvailableToday = true }
            };
            foreach (var doctor in doctorsWithSpecialization)
            {
                doctorService.AddDoctor(doctor);
            }

            // Act
            var result = doctorService.GetDoctorsWithSpecialization(specialization);

            // Assert
            Assert.AreEqual(doctorsWithSpecialization, result);
        }

        [Test]
        public void GetDoctorsWithSpecialization_Fail()
        {
            // Arrange
            var specialization = "Cardiologist"; // Assuming no doctor with this specialization exists

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorsWithSpecialization(specialization));
        }

        [Test]
        public void UpdateDoctor_Success()
        {
            // Arrange
            var doctorToUpdate = new Doctor()
            {
                Name = "John",
                Specialization = "Dentist",
                Experience = 10,
                Fees = 200,
                AvailableToday = true
            };
            doctorService.AddDoctor(doctorToUpdate);
            doctorToUpdate.Name = "Updated John"; // Update doctor's name

            // Act
            var result = doctorService.UpdateDoctor(doctorToUpdate);

            // Assert
            Assert.AreEqual(doctorToUpdate, result);
        }

        [Test]
        public void UpdateDoctor_Fail()
        {
            // Arrange
            var doctorToUpdate = new Doctor()
            {
                Name = "Emily",
                Specialization = "Pediatrician",
                Experience = 8,
                Fees = 250,
                AvailableToday = true
            };

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.UpdateDoctor(doctorToUpdate));
        }


    }
}