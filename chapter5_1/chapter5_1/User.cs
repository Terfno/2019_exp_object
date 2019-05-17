using System;

namespace Records
{
    public class User
    {
        private string familyName;
        private string firstName;

        public void SetUserName(string name)
        {
            Cache.name = name;
            string[] nameParts = name.Split(' ');
            familyName = nameParts[0];
            firstName = nameParts[1];
        }

        public string GetUserName()
        {
            return familyName + " " + firstName;
        }
    }

    class Cache
    {
        public static string name = "";
    }
}
