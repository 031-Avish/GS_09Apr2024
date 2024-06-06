CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Specialization VARCHAR(255),
    Experience FLOAT,
    Fees FLOAT,
    AvailableToday BIT
);

CREATE TABLE Patients (
    PatientId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    DateOfBirth DATE,
    PhoneNo VARCHAR(20),
    Gender VARCHAR(10)
);

CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY,
    DoctorId INT,
    PatientId INT,
    AppointmentDateAndTime DATETIME,
    Status VARCHAR(50),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId)
);
select * from Doctors
delete from Doctors
DBCC CHECKIDENT ('Doctors', RESEED, 0);