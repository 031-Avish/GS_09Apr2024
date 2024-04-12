using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Doctor
{
    internal class Doctor
    {
        /// <summary>
        /// Constuctor for initial value of Doctor attributes 
        /// </summary>
        public Doctor()
        {
            int Id = 0;
            string Name=string.Empty;
            int Age = 0;
            string Qualification = string.Empty;
            int Experience = 0;
            string Speciality= string.Empty;    
        }

        /// <summary>
        /// constructor to set doctors id 
        /// </summary>
        /// <param name="id"></param>
        public Doctor(int id)
        {
            Id = id;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int Experience {  get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        /// <summary>
        /// Method to Print details of the doctor 
        /// </summary>
        public void PrintDoctorsDetail()
        {
             Console.WriteLine(" --------------------------------------------");
             Console.WriteLine($"Doctors Id       \t:\t {Id}");
             Console.WriteLine($"Doctors Name      \t:\t {Name}");
             Console.WriteLine($"Doctors Age        \t:\t {Age}");
             Console.WriteLine($"Doctors Exp         \t:\t {Experience}");
             Console.WriteLine($"Doctots speciality   \t:\t {Speciality}");
             Console.WriteLine($"Doctots Qualification \t:\t {Qualification}");

        }
    }
}
