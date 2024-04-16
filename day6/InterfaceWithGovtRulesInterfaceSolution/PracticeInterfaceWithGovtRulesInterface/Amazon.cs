using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeInterfaceWithGovtRulesInterface
{
    public class Amazon : Company
    {
        public float TotalTimeInCompany {  get; set; }
        /// <summary>
        /// Amazon Constructor
        /// </summary>
        public Amazon()
        {
            TotalTimeInCompany = 0;
        }
        /// <summary>
        /// Parameterized constructor of Employee class
        /// </summary>
        /// <param name="empId"> Employee Id</param>
        /// <param name="name">Employee Name</param>
        /// <param name="department"> Employee Department </param>
        /// <param name="desg"> Employee Desg</param>
        /// <param name="basicSalary"> Employee Basic Salary </param>
        /// <param name="totalTimeInCompany">Employee Experinece in company</param>
        public Amazon(int empId, string name, string department, string desg, double basicSalary,float totalTimeInCompany) : base(empId, name, department, desg, basicSalary)
        {
            TotalTimeInCompany = totalTimeInCompany;
        }

        /// <summary>
        ///  overriden method to calculate The PF
        /// </summary>
        /// <param name="basicSalary">Basic Salary in Double </param>
        /// <returns> pf of employee </returns>

        public override double EmployeePF(double basicSalary)
        {
            double TotalPf = (12 * basicSalary) / 100;
            double employerPf = (8.33 * basicSalary) / 100;
            double employeepf = (3.67 * basicSalary) / 100;
            return employeepf;
        }

        /// <summary>
        /// overriden To caculate the Gratitity 
        /// </summary>
        /// <param name="serviceCompleted">float Experience in Company </param>
        /// <param name="basicSalary"> Basic Salary in Double </param>
        /// <returns> Gatituty Amount </returns>
        public override double GratutityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted < 5)
                return 0;
            else if (serviceCompleted >= 5 && serviceCompleted <= 10)
                return basicSalary/12;
            else if (serviceCompleted > 10 && serviceCompleted <= 20)
                return (2 * basicSalary)/12;
            else if (serviceCompleted > 20)
                return (3 * basicSalary)/12;
            return 0;
        }
        /// <summary>
        /// TO get the leave details 
        /// </summary>
        /// <returns> Details of leave </returns>

        public override string LeaveDetails()
        {
            return "Employee get 1 day of Casual Leave per month\r\n " +
                "12 days of Sick Leave per year\r\n" +
                "10 days of Privilege Leave per year ";
        }
    }
}
