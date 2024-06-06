

namespace PracticeInterfaceWithGovtRulesInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Amazon amazon = new Amazon(101,"Avish", "IT", "Emgineer", 60000,6);
            amazon.PrintEmployeeDetail();
            program.CalcuateSalaryAfterReduction(amazon ,amazon.BasicSalary, amazon.TotalTimeInCompany);

            Accenture accenture = new Accenture(101,"Aman", "IT", "Data Engineer" , 80000, 8);
            accenture.PrintEmployeeDetail();
            program.CalcuateSalaryAfterReduction(accenture, accenture.BasicSalary, accenture.TotalTimeInCompany);

        }
        /// <summary>
        /// To Calcuate the final In hand Salary before tax 
        /// </summary>
        /// <param name="Grule"> Object </param>
        /// <param name="BasicSalary"> basic salary of employee </param>
        /// <param name="TotalTimeInCompany"> Time worked in same company</param>

        void CalcuateSalaryAfterReduction( GovtRules Grule , double BasicSalary , float TotalTimeInCompany )
        {
            double pfReduction = Grule.EmployeePF(BasicSalary);
            double gratutityAmount= Grule.GratutityAmount(TotalTimeInCompany,BasicSalary);
            PrintSalaryAndLeaveDetail(Grule,pfReduction, gratutityAmount,BasicSalary);
        }
        /// <summary>
        /// print All the details of salary and leave 
        /// </summary>
        /// <param name="Grules">Object of any company </param>
        /// <param name="pfReduction"> pf of employee</param>
        /// <param name="gratitude"> Gratitude of employee</param>
        /// <param name="BasicSalary">basic Salary of employee </param>
        void PrintSalaryAndLeaveDetail( GovtRules Grules ,double pfReduction, double gratitude, double BasicSalary)
        {
            Console.WriteLine("Pf reduction from Employee Basic Salary is       :"+ pfReduction);
            Console.WriteLine("Gratitude reducted form Employee Basic Salary is : "+ gratitude);
            Console.WriteLine($"Monthly Salary after Deduction is               : {BasicSalary - (pfReduction + gratitude)}" );
            Console.WriteLine("Leave Details are                                : "+ Grules.LeaveDetails());
        }
    }
}
