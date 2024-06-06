using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeInterfaceWithGovtRulesInterface
{
    public class Company : GovtRules
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Desg { get; set; }
        public double BasicSalary { get; set; }

        /// <summary>
        /// Construtor of Company class
        /// </summary>
        public Company()
        {
            EmpId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Desg = string.Empty;
            BasicSalary = 0;
        }

        /// <summary>
        /// Parameterized constructor of Company class
        /// </summary>
        /// <param name="empId"> Employee Id</param>
        /// <param name="name">Employee Name</param>
        /// <param name="department"> Employee Department </param>
        /// <param name="desg"> Employee Desg</param>
        /// <param name="basicSalary"> Employee Basic Salary </param>
        public Company(int empId, string name, string department, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Desg = desg;
            BasicSalary = basicSalary;
        }
        
        public virtual double EmployeePF(double basicSalary)
        {
            return 0;
        }

        public virtual double GratutityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public virtual string LeaveDetails()
        {
            return 0;
        }

        /// <summary>
        /// to print all the details of a employee
        /// </summary>
        public void PrintEmployeeDetail()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Employee Id          :\t" + EmpId);
            Console.WriteLine("Employee Name        :\t" + Name);
            Console.WriteLine("Date of Department   :\t" + Department);
            Console.WriteLine("Employee desg        :\t" + Desg);
            Console.WriteLine("Employee BasicSalary :\t" + BasicSalary);
            Console.WriteLine("--------------------------------------");
        }
    }
}
