namespace firstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Hello, World!");
            //int num1 = 100, num2 = 200;
            //Console.WriteLine("the value of num1 is" + num1);
            //Console.WriteLine("the value of num2 is" + num2);
            //Console.WriteLine($"the sum of {num1} and {num2} is {num1 + num2}");

            //string Inp;
            //Inp = Console.ReadLine();
            //Console.WriteLine("input is " + Inp);
            //int num = int.Parse(Console.ReadLine());
            //num++;
            //Console.WriteLine(num);

            //string temp = null;
            //// int tempv=int.Parse(temp);// this will give an exception 
            //int tempv = Convert.ToInt32(temp);
            //Console.WriteLine(tempv);


            float fnum=Convert.ToSingle(Console.ReadLine());
            int inum = (int)fnum;
            Console.WriteLine(inum);
            int temp;
            bool val =int.TryParse(Console.ReadLine(), out temp);
        }
    }
}
