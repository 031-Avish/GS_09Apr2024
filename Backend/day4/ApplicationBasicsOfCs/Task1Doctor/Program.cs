using System.Dynamic;
using System.Numerics;

namespace Task1Doctor
{
    internal class Program
    {
        /// <summary>
        /// Create a doctor and return a doctor object 
        /// </summary>
        /// <param name="id"> take a id of doctor</param>
        /// <returns></returns>
        Doctor CreateDoctorViaConsole(int id)
        {
            Doctor doctor = new Doctor(id);
            Console.WriteLine(" --------------------------------------------");
            // get name 
            Console.WriteLine("Please enter Doctor's name ");
            doctor.Name = Console.ReadLine();

            // get age
            int age;
            Console.WriteLine("Enter Doctor's age");
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.WriteLine("invalid entry , try again");
            }
            doctor.Age = age;

            //get experience
            int experience;
            Console.WriteLine("Enter Doctor's experience");
            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
            {
                Console.WriteLine("invalid entry , try again");
            }
            doctor.Experience = experience;

            // get qualification 
            Console.WriteLine("Please enter doctor's Qualification");
            doctor.Qualification = Console.ReadLine();

            // get Speciality 
            Console.WriteLine("Please enter doctor's Speciality");
            doctor.Speciality = Console.ReadLine();
            
            return doctor;
        }
        /// <summary>
        /// Get total number of Doctor Initial 
        /// </summary>
        /// <returns> return the count for doctors array</returns>

        int GetDoctorsCount()
        {
            //current using it because I dont know replacment of VECTOR , that can grow and shrink 
            Console.WriteLine("Please Enter total number of doctors ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("invalid entry , try again");
            }
            
            return count;
        }

        /// <summary>
        /// function to get the doctor by the user entered specialization
        /// </summary>
        /// <param name="doctors">complete array of doctors </param>
        void GetDoctorBySpecialization(Doctor[] doctors)
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine("Please enter doctor's Speciality for searching");
            string speciality = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("All doctors detail with given Specialization are : ");
            for (int i = 0; i < doctors.Length; i++)
            {
                if (doctors[i].Speciality == speciality)
                {
                    doctors[i].PrintDoctorsDetail();
                    
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Sorry!! There is no such doctor with given Specialization Try Again");

                while (true)
                {
                    Console.WriteLine(" --------------------------------------------");
                    Console.WriteLine("Do you want to try again YES or NO");
                    string inp = Console.ReadLine();
                    if (inp == "YES")
                    {
                        GetDoctorBySpecialization(doctors);
                        break;
                    }
                    else if (inp == "NO")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice");
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();    
            int count = program.GetDoctorsCount();
            Doctor[] doctors = new Doctor[count];
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = program.CreateDoctorViaConsole(100+i);
            }
            for (int i = 0;i<doctors.Length;i++)
            {
                doctors[i].PrintDoctorsDetail();
            }
            program.GetDoctorBySpecialization(doctors);
        }
    }
}
