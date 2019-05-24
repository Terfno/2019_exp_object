using System;

namespace Record
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

        public virtual string GetUserName()
        {
            return familyName + " " + firstName;
        }
    }

    class Student : User
    {
        private string studentID;
        private int entryYear;
        private int no;

        public Student(int no,int entryYear,string familyName,string firstName) : base(familyName, firstName)
        {
            this.no = no;
            this.entryYear = entryYear;
            this.studentID = "u" + firstName[1].ToString() + (entryYear - 100 * (entryYear / 100)).ToString() + string.Format("{0:00}", no);
        }

        public string GetID()
        {
            return this.studentID;
        }
    }

    class Teacher : User
    {
        private string yakushoku;
        public Teacher(string yakushoku, string familyName, string firstName) : base(familyName, firstName)
        {
            this.yakushoku = yakushoku;
        }

        public override string GetUserName()
        {
            return this.yakushoku + base.GetUserName();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Student s = new Student(1, 2030, "Tanaka", "Taro");
            Teacher t = new Teacher("Prof.", "Takahashi", "Takashi");
            User u1 = t;
            User u2 = s;

            Console.WriteLine(u1.GetUserName());
            Console.WriteLine(u2.GetUserName());

            Console.ReadKey();
        }
    }
}
