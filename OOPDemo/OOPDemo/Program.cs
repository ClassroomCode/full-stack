namespace OOPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            var p = new Person();
            p.FirstName = "Bill";
            p.LastName = "Gates";
            people.Add(p);

            var emp = new Employee();
            emp.FirstName = "Steve";
            emp.LastName = "Jobs";
            emp.Salary = 100000;
            people.Add(emp);

            for (int i = 0; i < people.Count; i++)
            {
                Person person = people[i];
                Console.WriteLine(person.FullName);
            }
            /*
            foreach (Person x in people)
            {
                Console.WriteLine(x.FullName);
            }
            */
        }
    }
}
