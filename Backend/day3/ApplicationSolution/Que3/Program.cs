namespace Que3
{
    internal class Program
    {
        static int TakeInput()
        {
            int num1;
            Console.WriteLine("Please enter the the number and negative to end");
            while (int.TryParse(Console.ReadLine(), out num1) == false)
                Console.WriteLine("Invalid entry. Please enter a interger number");
            return num1;
        }
        static void FindConditionalAvg()
        {
            int num = TakeInput();
            int count = 0;
            int sum = 0;
            while (num >= 0)
            {
                if (num % 7 == 0)
                {
                    count++;
                    sum += num;
                }
                num = TakeInput();
            }
            if (sum == 0)
                PrintMaxValue(0, "None of the number is divisible by 7");
            else
                PrintMaxValue(sum / (double)count, "Average of number divisible by 7 is");
        }
        static void PrintMaxValue(double max, string message)
        {
            Console.WriteLine($"{message} : {max}");
        }
        static void Main(string[] args)
        {
            FindConditionalAvg();
        }
    }
}
