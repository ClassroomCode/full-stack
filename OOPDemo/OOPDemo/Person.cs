
namespace OOPDemo
{
    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public virtual string FullName => $"{FirstName} {LastName}";

        /*
         * 1. Properties should not throw exceptions (try/catch)
         * 2. Properties should not possibly take a long time to execute (thread)
         * 3. Properties should result in same end state no matter how many times called
         */
    }

    internal class Employee : Person
    {
        public double Salary { get; set; }

        public override string FullName => $"{LastName}, {FirstName}";
    }
}
