using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeInterfaceWithGovtRulesInterface
{
    /// <summary>
    /// A Accenture class Extending from Company Class
    /// </summary>
    public class Accenture:Company
    {
        public float TotalTimeInCompany {  get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Accenture()
        {
            TotalTimeInCompany = 0f;
        }
        /// <summary>
        /// Parameterized constructor of Accenture class
        /// </summary>
        /// <param name="empId"> Employee Id</param>
        /// <param name="name">Employee Name</param>
        /// <param name="department"> Employee Department </param>
        /// <param name="desg"> Employee Desg</param>
        /// <param name="basicSalary"> Employee Basic Salary </param>
        /// <param name="totalTimeInCompany">Employee Experinece in company</param>

        public Accenture(int empId, string name, string department, string desg, double basicSalary, float totalTimeInCompany) : base(empId, name, department, desg, basicSalary)
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
            double employerPf = (0 * basicSalary) / 100;
            double employeepf = (12 * basicSalary) / 100;
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
            return 0;
        }

        /// <summary>
        /// TO get the leave details 
        /// </summary>
        /// <returns> Details of leave </returns>

        public override string LeaveDetails()
        {

            return "Employee get 2 day of Casual Leave per month\r\n " +
                "5 days of Sick Leave per year\r\n" +
                "5 days of Previlage Leave per year\r\n";
        }
    }
}
