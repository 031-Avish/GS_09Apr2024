namespace Que7
{
    internal class Program
    {
        static string TakeInput()
        {
            Console.WriteLine("enter string sepreated with coma");
            string str = Console.ReadLine() ?? "0";
            while (str == "0")
            {
                Console.WriteLine("You entered null value please enter your name");
                str = Console.ReadLine() ?? "0";
            }
            return str ;
        }
        static int WordCount(string str)
        {
            string[] words = str.Split(',');

            return words.Length;
        }
        static string WordWithLeastVovel(string str)
        {
            string[] words = str.Split(',');
            int min=int.MaxValue;
            string result="";
            foreach(string word in words) {
                int counter = 0;
                foreach(char ch in word)
                {
                    if("aeiouAEIOU".Contains(ch)) {
                    counter++;
                    }
                }
                if(counter < min) {
                    min = counter;
                    result = word;
                }
            }
            return result;
        }
        static void WordAndVovel()
        {
            string str = TakeInput();
            int wordcount = WordCount(str);
            PrintResult(wordcount, "total words in string are ");
            string result = WordWithLeastVovel(str);
            Console.WriteLine("the first word with least vovel is " + result);
        }
        static void PrintResult(int max, string message)
        {
            Console.WriteLine($"{message} : {max}");
        }
        static void Main(string[] args)
        {
            WordAndVovel();
        }
    }
}
