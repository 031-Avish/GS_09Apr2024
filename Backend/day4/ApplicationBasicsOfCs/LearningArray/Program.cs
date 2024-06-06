namespace LearningArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ages = new int[3];
            ages[0] = 25;
            ages[1] = 23;
            ages[2] = 32;
            for (int i = 0; i < ages.Length; i++)
            {
                Console.WriteLine(ages[i]);
            }
            int count = 0;
            while (count < ages.Length)
            {
                Console.WriteLine(ages[count]);
                count++;
            }
            count = 0;
            do
            {
                Console.WriteLine(ages[count]);
                count++;
            } while (count < ages.Length);
        }
    }
}
