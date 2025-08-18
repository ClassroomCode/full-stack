namespace OOPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();

            p.FirstName = "Bill";
            p.LastName = "Gates";

            Console.WriteLine(p.FullName);
        }
    }
}
