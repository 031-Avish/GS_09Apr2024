using RequestTrackerModelLibrary;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {

        void UnderstandingArrayList()
        {
            ArrayList list=new ArrayList();
            list.Add(100);
            list.Add("avish");
            list.Add(23.4);
            list.Add(90.0f);
            list.Add(new Employee(101, "Ramu", new DateTime(), "Admin"));

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        void UnderstandingGenricList() {
            List<int> numbers=new List<int>();
            numbers.Add(100);
            numbers.Add(101);
            numbers.Add(50);
            double sum = 0;
            //for(int i = 0;i<numbers.Count;i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //    sum+= numbers[i];
            //}
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
                sum += i;
            }
            Console.WriteLine("total is " + sum);

        }

        void UnderstandingSet()
        {
            HashSet<string> names=new HashSet<string>()
            {
                "ramu","binu"
            };
            names.Add("somu");
            names.Add("ramu");
            names.Add("kalu");

            foreach(string i in names)
            {
                Console.WriteLine(i);
            }
        }
        void UnderstandingDictionary()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Ramu");
            employees.Add(102, "Komu");
            employees.Add(103, "Bimu");
            employees.Add(104, "Ramu");
            foreach (var key in employees.Keys)
            {
                Console.WriteLine(key + " " + employees[key]);
            }
            employees[105] = "shyam";
            Console.WriteLine(employees[105]);
            if (employees.ContainsKey(101))
                Console.WriteLine("employee 101 present and name is " + employees[101]);
            if (employees.ContainsValue("Somu"))
                Console.WriteLine("there is an emploeye with name Somu in teh collection");
        }
        static void Main(string[] args)
        {
            Program program = new Program();    
            //program.UnderstandingArrayList();
            //program.UnderstandingGenricList();
            //program.UnderstandingSet();
            program.UnderstandingDictionary();

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
