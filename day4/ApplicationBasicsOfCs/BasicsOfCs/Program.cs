namespace BasicsOfCs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee employee = new Employee();
            employee.Id = 1000;
            employee.Name = "Avish";
            Console.WriteLine(employee.Id);
            Console.WriteLine(employee.Name);

            Employee employee2 = new Employee() {
                Id = 1001,
                Name = "Ramu",
                Salary = 40000,
                DateOfBirth = new DateTime(2000, 08, 12),
                Email="ramu@abc.com"

            };
            Console.WriteLine(employee2.Id);
            Console.WriteLine(employee2.Name);
            Console.WriteLine(employee2.Salary);
            Console.WriteLine(employee2.DateOfBirth);
            Console.WriteLine(employee2.Email);

            Employee employee3 = new Employee(1002, "nanam", 50000, new DateTime(2000, 5, 20), "naman@gmail.com");
            Console.WriteLine(employee3.Salary);

            employee.Work();

        }
    }
}
