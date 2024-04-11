namespace Que5
{
    internal class Program
    {
        static string TakeUsername()
        {
            Console.WriteLine("enter username");
            string username=Console.ReadLine()??"0";
            while(username == "0")
            {
                Console.WriteLine("You entered null value please enter your name");
                username = Console.ReadLine() ?? "0";
            }
            return username;
        }
        static string TakePassword()
        {
            Console.WriteLine("enter password");
            string password = Console.ReadLine()??"0" ;
            while (password == "0")
            {
                Console.WriteLine("You entered null value please enter your name");
                password = Console.ReadLine() ?? "0";
            }
            return password;
        }
        static bool Check(string username, string password)
        {
            if(username=="ABC" && password == "123")
            {
                Console.WriteLine("Congratulation you entered correct password");
                return true;
            }
            return false;

        }
        static void ValidateUser()
        {
            string username = TakeUsername();
            string password = TakePassword();
            int countAttempts = 3;
            while(!Check(username, password) && countAttempts>1)
            {
                countAttempts--;
                Console.WriteLine($"wrong Password try again attempts left {countAttempts}");
                username = TakeUsername();
                password = TakePassword();
            }
            if (countAttempts <=1)
            {
                Console.WriteLine("maximum attempts limit exceeded");
            }
        }
        static void Main(string[] args)
        {
            ValidateUser();
        }
    }
}
