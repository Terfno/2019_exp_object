using System;
using chapter5_1;
using Records;

namespace chapter5_1
{
    class chapter5_1
    {
        static void Main(string[] args)
        {
            User u = new User();

            u.SetUserName("Tnaka Taro");

            string uname = u.GetUserName();

            Console.WriteLine(uname);
            Console.ReadKey();
        }
    }

}
