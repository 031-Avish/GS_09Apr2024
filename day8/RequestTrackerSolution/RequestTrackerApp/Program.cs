using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Collections;
using System.Xml.Linq;

namespace RequestTrackerApp
{
    internal class Program
    {

        void AddDepartment()
        {

            DepartmentBL departmentBL = new DepartmentBL();
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();    
            program.AddDepartment();
            //program.AddEmployee();

            //Employee employee1, employee2;

            //employee1 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
            //employee2 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
            //if (employee1.Equals(employee2))
            //{
            //    Console.WriteLine("Both Same");
            //}
            //else
            //{
            //    Console.WriteLine($"{employee1} and {employee2} are Not same employee");
            //}
        }
    }
}
