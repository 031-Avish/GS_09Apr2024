

namespace ExcelSheetColumnTitle
{
    internal class ExcelSheetColumn
    {
        static async Task Main(string[] args)
        {
            int colNum = TakeInput();
            Dictionary<int, char> intTocharMap = await MakeMap();
            string result =  await CalculateTitle(colNum, intTocharMap);
            Console.WriteLine("The column title is  : " + result );
        }

        private static async Task<string> CalculateTitle(int colNum, Dictionary<int, char> mp)
        {
            string result = "";
            while (colNum > 26)
            {
                int rem = colNum % 26;
                colNum /= 26;
                if (rem == 0)
                {
                    rem = 26;
                    colNum -= 1;
                }
                result += mp[rem];
            }
            result += mp[colNum];
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static async Task<Dictionary<int, char>> MakeMap()
        {
            Dictionary<int, char> mp = new Dictionary<int, char>();
            char c = 'A';
            for (int i = 1; i <= 26; i++)
            {
                mp[i] = c;
                c += (char)1;
            }
            return mp;
        }

        private static int TakeInput()
        {
            Console.WriteLine("Enter the column number");
            int colNum;
            while (!int.TryParse(Console.ReadLine(), out colNum))
            {
                Console.WriteLine("enter interger only");
            }
            return colNum;
        }
    }
}
