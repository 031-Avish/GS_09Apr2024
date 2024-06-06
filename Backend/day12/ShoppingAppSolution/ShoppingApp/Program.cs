using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Xml.Linq;
using static ShoppingModelLibrary.Customer;

namespace ShoppingApp
{
    internal class Program
    {

        // 1.create a  delegate similar to function same return type and same parameters 
        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method

        public delegate T calcDel<T>(T n1, T n2);
        // Calculate method taking the calcDel type of method and then calling the original method
        //void Calculate(calcDel<int> cal,string toPrint)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The {toPrint} of {n1} and {n2} is {result}");
        //}


        void Calculate(Func<int,int,int> cal, string toPrint)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The {toPrint} of {n1} and {n2} is {result}");
        }


        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}
        //public int Multiply(int num1,int num2)
        //{
        //    return num1 * num2;
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();

            // 2. Create a reference of delegate type 
            //calcDel<int> c1 = new calcDel<int>(program.Add);
            //calcDel<int> c2 = new calcDel<int>(program.Multiply);
            //call  the calculate method by passing the reference of type delegate
            //program.Calculate(c2,"Multiple");

            //calcDel<int> c1 = delegate (int num1, int num2)
            //{
            //    return (num1 + num2);
            //};

            //calcDel<int> c1= (int num1,int num2 )=> (num1 + num2);


            //Func<int,int,int> c1= (num1,num2)=>(num1+num2); 
            //program.Calculate(c1,"Sum");


            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            //int[] another = new int[numbers.Length];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] > 80)
            //        another[i] = numbers[i];
            //}
            //for (int i = 0;i < another.Length; i++)
            //{
            //    Console.WriteLine(another[i]);
            //}
            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            ////select * from numbers where num>80
            //// var another = from n in numbers where n > 80 select n;
            ////var another = numbers.Where(n => n > 80);
            //var another = numbers.OrderBy(n => n);
            //foreach(int n in another)
            //    Console.WriteLine(n);

            IRepository<int, Customer> customerRepo = new CustomerRepository();
            customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 33 });
            customerRepo.Add(new Customer { Id = 2, Name = "Ramu", Age = 31 });
            customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 27 });
            var customers = customerRepo.GetAll().ToList();
            //customers.Sort(new SortCustomerByName());

            //customers=customers.OrderBy(cust => cust.Name).ThenBy(cust=>cust.Age).ToList();
            //customers = customers.OrderByDescending(cust => cust.Name).ThenBy(cust => cust.Age).ToList();
            customers = customers.OrderByDescending(cust => cust.Name).ThenByDescending(cust => cust.Age).ToList();


            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            // extension methods 
            int[] evenNumebrs = numbers.EvenCatch();
            foreach (int n in evenNumebrs)
                Console.WriteLine(n);
            //string message = "Hello World";
            //message = message.Reverse();
            //Console.WriteLine(message);
            string msg = "asdfghjk";
            //Extensions method
            msg= msg.Reverse();
            Console.WriteLine(msg);
        }

    }
    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();
        }
    }
}
