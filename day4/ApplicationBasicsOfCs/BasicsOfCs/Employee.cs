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

        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id) // constuctor chaining 
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public void Work()
        {
            Id = 101;
            Console.WriteLine("Work");
        }
    }
}
