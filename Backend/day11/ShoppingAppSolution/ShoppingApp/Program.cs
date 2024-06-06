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


            Func<int,int,int> c1= (num1,num2)=>(num1+num2); 
            program.Calculate(c1,"Sum");

        }
    }
}
