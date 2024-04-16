using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeInterfaceWithGovtRulesInterface
{
    /// <summary>
    /// Govt Rules interface 
    /// </summary>
    public interface GovtRules
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double GratutityAmount(float serviceCompleted, double basicSalary);
    }
}
