using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfCs
{
    class Employee
    {
        // int id;
        //public int GetId()
        //{
        //    return id;
        //}
        //public void PutId(int eid)
        //{
        //    id = eid;
        //}
        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        //public int Id
        //{
        //    get => id;
        //    set => id = value;
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        double salary;
        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return salary-salary*10/100;
            } 
        }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        // default constructor 
        public Employee()
        {
            Id = 0; 
            Name = string.Empty;
            Email = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Salary = 0; 
        }
        // parameterized constructor
        public Employee(int id)
        {
            Id = id;
        }
        /// <summary>
        /// Constructor to initialize the value of Employees
        /// </summary>
        /// <param name="id">Id of Employee</param>
        /// <param name="name">Name of the Employee</param>
        /// <param name="salary">Salary Of Employee Without deduction</param>
        /// <param name="dateOfBirth"> Date of birth Of Employee</param>
        /// <param name="email">Email of the Employee</param>
        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id) // constuctor chaining 
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
        /// <summary>
        /// Prints Details of all the employee 
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee Id \t:\t {Id}");
            Console.WriteLine($"Employee Name \t:\t {Name}");
            Console.WriteLine($"Employee Date of Birth \t:\t {DateOfBirth}");
            Console.WriteLine($"Employee Salary \t:\t {Salary}");
            Console.WriteLine($"Employee Email \t:\t {Email}");
        }
        /// <summary>
        /// the work employee do 
        /// </summary>
        public void Work()
        {
            Id = 101;
            Console.WriteLine("Work");
        }
    }
}
