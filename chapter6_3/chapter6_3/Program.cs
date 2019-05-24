using System;

namespace chapter6_3
{
    class User
    {
        private string familyName;
        private string firstName;

        public User(string familyName, string firstName)
        {
            this.familyName = familyName;
            this.firstName = firstName;
        }

        public string GetUserName()
        {
            return familyName + " " + firstName;
        }

        public static void Main(string[] args)
        {
            User u = new User("Suzuki", "Ichiro");

            Console.WriteLine(u.GetUserName());
            Console.ReadKey();
        }
    }
}
