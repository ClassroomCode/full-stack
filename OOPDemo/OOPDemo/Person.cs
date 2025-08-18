
namespace OOPDemo
{
    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string FullName => $"{FirstName} {LastName}";

        /*
         * 1. Properties should not throw exceptions (try/catch)
         * 2. Properties should not possibly take a long time to execute (thread)
         * 3. Properties should result in same end state no matter how many times called
         */
    }
}
