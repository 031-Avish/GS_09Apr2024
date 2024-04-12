
using System.Net.Http.Headers;

namespace CardValidator
{
    internal class Program
    {
        /// <summary>
        /// function to take Card number from user
        /// </summary>
        /// <returns> the card number </returns>

        string TakeUserInput()
        {
            Console.WriteLine("Enter a visa card number ");
            string CardNumber=Console.ReadLine();
            while (!ValidateInput(CardNumber))
            {
                Console.WriteLine("Not a correct input !!!! Try again");
                CardNumber = Console.ReadLine();    
            }
            return CardNumber;
        }
        /// <summary>
        /// To check function to validate Cardnumber contains digits only   
        /// </summary>
        /// <param name="input">Card number</param>
        /// <returns> correct card number or not (true/false)</returns>
        bool IsStringInteger(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// check user input valid or not 
        /// </summary>
        /// <param name="cardNumber"> Card Number </param>
        /// <returns>true/false</returns>

        bool ValidateInput(string cardNumber)
        {
            if(cardNumber.Length!=16)
                return false;
            if(string.IsNullOrEmpty(cardNumber))
                return false;
            if(!IsStringInteger(cardNumber))
                return false ;
            return true;
        }
        /// <summary>
        /// function to reverse the card number
        /// </summary>
        /// <param name="input">Card number</param>
        /// <returns> reverse of that card number</returns>
        string ReverseCardNumber(string input)
        {
            string ReversedCardNumber = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                ReversedCardNumber += input[i];
            }
            return ReversedCardNumber;
        }
        /// <summary>
        /// sum of the digits if greater than 9 
        /// </summary>
        /// <param name="digit">sum when multiply by 2 </param>
        /// <returns>return single digit number</returns>
        int SumUntilSingleDigit(int digit)
        {
            int sum = 0;
            while (digit != 0)
            {
                sum += digit % 10;
                digit /= 10;
            }
            
            return sum;
        }
        /// <summary>
        /// to validate the card number
        /// </summary>
        /// <param name="cardNumber"></param>
        void ValidateCardNumber(string cardNumber)
        {
            string ReversedCardNumber=ReverseCardNumber(cardNumber);
            int sum = 0;

            for (int i = 0; i < ReversedCardNumber.Length; i++)
            {
                int digit = int.Parse(ReversedCardNumber[i].ToString());
                if (i%2!=0)
                {
                    digit *= 2;
                    while (digit > 9)
                    {
                        digit = SumUntilSingleDigit(digit);
                    }
                }
                sum += digit;
            }
            Console.WriteLine(sum);
            bool result =sum % 10 == 0;
            PrintResult(result);
        }
        /// <summary>
        /// print the result 
        /// </summary>
        /// <param name="result"> result i.e valid or not </param>
        void PrintResult(bool result)
        {
            if (result)
            {
                Console.WriteLine("Yes it is a Valid Card Number");
                return;
            }
            Console.WriteLine("Not a valid card number ");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            string CardNumber = program.TakeUserInput();
            program.ValidateCardNumber(CardNumber);
        }
    }
}
