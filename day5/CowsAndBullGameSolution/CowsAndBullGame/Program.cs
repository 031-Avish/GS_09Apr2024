


using System.Runtime.InteropServices;

namespace CowsAndBullGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();    
            string WordToGuess = "golf";
            int[] letterCount = program.CountLetterInWordToGuess(WordToGuess);
            program.StartTheGame(letterCount, WordToGuess);

        }
        /// <summary>
        /// The function will start a game and ask user to enter a word until guessed correct
        /// </summary>
        /// <param name="letterCount">Array having count of guessed Words letters</param>
        /// <param name="WordToGuess">The word user has to guess to win</param>
        void StartTheGame(int[] letterCount, string WordToGuess)
        {
            int result = 1;
            do
            {
                int cows = 0;
                int bulls = 0;
                string word = TakeWordFromUser();
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == WordToGuess[i])
                    {
                        cows++;
                    }
                    else
                    {
                        if (letterCount[word[i] - 'a'] > 0)
                        {
                            bulls++;
                        }
                    }
                }
                PrintTheCowsAndBulls(cows, bulls);
                result =CheckTheWin(word, WordToGuess);
            } while (result!=0);
        }


        /// <summary>
        /// Function to check If the word and word to guess are same
        /// </summary>
        /// <param name="word"> word entered by user </param>
        /// <param name="WordToGuess"> word the user need to guess</param>
        /// <returns> return 0 if win and 1 when fail </returns>
        int CheckTheWin(string word, string WordToGuess)
        {
            if (WordToGuess == word)
            {
                Console.WriteLine("You Guessed it right!! YOU WON");
                return 0;
            }
            //Console.WriteLine("Press 0 to exit , 1 to try More ");
            //int reuslt;
            //while(!int.TryParse(Console.ReadLine(),out reuslt)){
            //    Console.WriteLine("Enter Correct input");
            //}
            return 1;
        }

        /// <summary>
        /// two print the present value of cow and bull
        /// </summary>
        /// <param name="cows"> value of cow ie. same letter same place </param>
        /// <param name="bulls"> value of bull ie. same letter diffent  place </param>
        void PrintTheCowsAndBulls(int cows, int bulls)
        {
            Console.WriteLine("cows = " + cows);
            Console.WriteLine("bulls = " + bulls);
            Console.WriteLine("----------------------------");
        }
        /// <summary>
        /// To count the number of letter in the word to guess
        /// </summary>
        /// <param name="WordToGuess"> take the word to guess </param>
        /// <returns> array of count of letter in word to guess </returns>

        int[] CountLetterInWordToGuess(string WordToGuess)
        {
            int[] letterCount=new int[26];
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (WordToGuess[i] >= 'a' && WordToGuess[i] <= 'z')
                {
                    letterCount[WordToGuess[i] - 'a']++;
                }
            }
            return letterCount;
        }

        /// <summary>
        /// function to take the word from the user and should be of 4 letters only 
        /// </summary>
        /// <returns> returns the user input </returns>
        string TakeWordFromUser()
        {

            Console.WriteLine("Enter a Word of length 4 ");
            string word = Console.ReadLine() ?? string.Empty;
            while(string.IsNullOrEmpty(word) || word.Length!=4)
            {
                Console.WriteLine("Only word of length 4 is allowed");
                word = Console.ReadLine() ?? string.Empty;
            }
            return word;
        }
    }
}
