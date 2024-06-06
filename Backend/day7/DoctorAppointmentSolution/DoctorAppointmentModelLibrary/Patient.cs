using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLibrary
{
    public class Patient
    {
        int age;
        DateTime dob;
        public int PatientId { get; set; }  

        public string Name { get; set;}
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                age = (DateTime.Today - dob).Days / 365;

            }
        }
        public string PhoneNo { get; set; }
        public Patient()
        {
            PatientId = 0;
            Name = string.Empty;
            DateOfBirth = new DateTime();
            age = 0;
            PhoneNo = "0000000000";
            Gender=string.Empty;
        }
        public string Gender { get; set; } = string.Empty;
        public Patient(int patientId, string name, DateTime dateOfBirth, string contactInfo,string gender)
        {
            PatientId = patientId;
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNo = contactInfo;
            Gender = Gender;
        }

        

        public virtual void BuildDoctorFromConsole()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Patients's Name");
            Name = Console.ReadLine() ?? String.Empty;

            Console.WriteLine("Please enter Patient Dob");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine( "Enter Patient's Phone Number");
            PhoneNo = Console.ReadLine() ?? String.Empty;

        }
        public virtual void PrintDoctorDetails()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Patient's Id " + PatientId);
            Console.WriteLine("Patient's Name " + Name);
            Console.WriteLine("Patient's Dob " + DateOfBirth);
            Console.WriteLine("Doctor's Age " + Age);
            
        }

        public override bool Equals(object? obj)
        {
            return this.PatientId.Equals((obj as Patient).PatientId);
        }
        public override string ToString()
        {
            return "\nPatient's Id " + PatientId +
               "\nPatient's Name " + Name +
                "\nPatient's Age " + Age +
                "\nPatient's Dob is  " + DateOfBirth;
        }

    }
}
