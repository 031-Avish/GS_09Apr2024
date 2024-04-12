namespace BasicsOfCs
{
    internal class Program
    {
        Employee CreateEmployeeByTakingDeatailsFromConsole(int id)
        {
            Employee employee = new Employee(id);
            Console.WriteLine("Please enter name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("please enter dob in yyyy/mm/dd");
            employee.DateOfBirth =Convert.ToDateTime(Console.ReadLine());   
            Console.WriteLine("Enter the email id ");
            employee.Email = Console.ReadLine();
            double salary;
            Console.WriteLine("Enter Employee salary");
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("invalid entry , try again");
            }
            employee.Salary = salary; 
            return employee;

        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Employee employee = new Employee();
            //employee.Id = 1000;
            //employee.Name = "Avish";
            //Console.WriteLine(employee.Id);
            //Console.WriteLine(employee.Name);

            //Employee employee2 = new Employee() {
            //    Id = 1001,
            //    Name = "Ramu",
            //    Salary = 40000,
            //    DateOfBirth = new DateTime(2000, 08, 12),
            //    Email="ramu@abc.com"

            //};
            ////Console.WriteLine(employee2.Id);
            ////Console.WriteLine(employee2.Name);
            ////Console.WriteLine(employee2.Salary);
            ////Console.WriteLine(employee2.DateOfBirth);
            ////Console.WriteLine(employee2.Email);

            //employee2.PrintEmployeeDetails();
            //Employee employee3 = new Employee(1002, "nanam", 50000, new DateTime(2000, 5, 20), "naman@gmail.com");
            //Console.WriteLine(employee3.Salary);
            //employee.Work();


            Program program = new Program();
            Employee[] employees = new Employee[2];
            for (int i = 0;i <employees.Length;i++)
            {
                employees[i] = program.CreateEmployeeByTakingDeatailsFromConsole((100 + i));
            }
            for (int i = 0; i <employees.Length;i++)
            {
                employees[i].PrintEmployeeDetails();    
            }


        }
    }
}
