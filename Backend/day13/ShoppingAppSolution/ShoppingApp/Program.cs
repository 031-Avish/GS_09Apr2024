using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Xml.Linq;
using static ShoppingModelLibrary.Customer;

namespace ShoppingApp
{
    internal class Program
    {
        //int GetResultFromDatabaseServer()
        //{
        //    return new Random().Next();
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    Program program = new Program();
        //    int number = program.GetResultFromDatabaseServer();
        //    Console.WriteLine("This is the random number from main " + new Random().Next());
        //    Console.WriteLine("This is the random number from server " + number);

        //}
        //async Task<int> GetResultFromDatabaseServer()
        //{
        //    Thread.Sleep(5000);
        //    return new Random().Next();
        //}
        void PrintNumbers()
        {
            lock (this)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                    Thread.Sleep(1000);
                }
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //var number = program.GetResultFromDatabaseServer();
            //Console.WriteLine("This is the random number from main" + new Random().Next());
            //Console.WriteLine("Hello dont waited");
            //Console.WriteLine("Hello Dont waited");
            //Console.WriteLine("Hello Dont waited");

            //Console.WriteLine("This is the random number from server " + number.Result);
            //var number1 = await program.GetResultFromDatabaseServer();

            //Console.WriteLine("Hello I waited");
            //Console.WriteLine(number1);
            Program program = new Program();
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");
        }
    }
    
}
