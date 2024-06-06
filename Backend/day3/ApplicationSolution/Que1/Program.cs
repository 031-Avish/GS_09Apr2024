namespace Que1
{
    internal class Program
    {
        static int Add(int num1, int num2)
        {
            checked
            {
                int result = num1 + num2;
                return result;
            }
        }
        static int Multiply(int num1, int num2)
        {
            checked
            {
                int result = num1 * num2;
                return result;
            }
        }
        static double Division(int num1, int num2)
        {
            if (num2 == 0)
                return 0;
            checked
            {
                double result = (double)num1 /(double) num2;
                return result;
            }
        }
        static int Substaction(int num1, int num2)
        {
            checked
            {
                int result = num1-num2;
                return result;
            }
        }
        static int Remainder(int num1, int num2)
        {
            checked
            {
                int result = num1 % num2;
                return result;
            }
        }

        static int TakeNumber()
        {
            int num1;
            Console.WriteLine("Please enter the the number");
            while (int.TryParse(Console.ReadLine(), out num1) == false)
                Console.WriteLine("Invalid entry. Please enter a interger number");
            return num1;
        }
        static void Calculate()
        {
            int num1, num2;
            num1 = TakeNumber();
            num2 = TakeNumber();
            int sum = Add(num1, num2);
            int multiply=Multiply(num1, num2);
            double division = Division(num1, num2);
            int substration = Substaction(num1, num2);
            int remainder = Remainder(num1, num2);
            PrintResult(sum, "Sum");
            PrintResult(multiply, "Multiple");
            PrintResultFloat(division, "Division");
            PrintResult(substration, "Sustraction");
            PrintResult(remainder, "Remainder");
        }
        static void PrintResultFloat(double ans, string ops)
        {
            Console.WriteLine($"The {ops} is {ans}");
        }
        static void PrintResult(int ans, string ops)
        {
            Console.WriteLine($"The {ops} is {ans}");
        }
        static void Main(string[] args)
        {
            Calculate();
        }
    }
}
