using System.Runtime.InteropServices;

namespace Que4
{
    internal class Program
    {
        static string TakeInput()
        {
            Console.WriteLine("enter your name");
            string username = Console.ReadLine()??"0";
            while (username =="0")
            {
                Console.WriteLine("You entered null value please enter your name");
                username = Console.ReadLine() ?? "0";
            }
            return username;
        }
        static void FindLength()
        {
            string username = TakeInput();
            PrintName(username.Length);
        }
        static void PrintName(int length)
        {
            Console.WriteLine($"Length of the user name is {length}");
        }
        static void Main(string[] args)
        {
            FindLength();
        }
    }
}
