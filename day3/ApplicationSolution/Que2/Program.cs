using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Que2
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
        static void FindMax()
        {
            int num=TakeInput();
            int max = int.MinValue;
            while(num>=0)
            {
                if (max < num)
                    max = num;
                num= TakeInput();
            }
            if (max == int.MinValue)
                PrintMaxValue(0, "No Positive value found");
            else
                PrintMaxValue(max, "Maximum Value is");
        }
        static void PrintMaxValue(int max, string message)
        {
            Console.WriteLine($"{message} : {max}");
        }
        static void Main(string[] args)
        {
            FindMax();
        }
    }
}
