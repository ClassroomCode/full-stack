namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>();

            while (true)
            {
                Console.Write("Please provide a number: ");
                string input = Console.ReadLine() ?? "0";
                int num;
                bool isNumber = int.TryParse(input, out num);
                if (!isNumber)
                {
                    Console.WriteLine("BAD NUMBER!");
                    continue;
                }
                else
                {
                    if (num == 0) break;
                    nums.Add(num);
                }
            }

            var evens = nums.ToArray();

            foreach (int even in evens)
            {
                Console.WriteLine(even);
            }
        }
    }
}
