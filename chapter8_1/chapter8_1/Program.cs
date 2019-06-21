using System;

namespace chapter8_1
{
    public class Earth
    {
        private static Earth own = null;

        private string creator;

        private Earth()
        {
            Console.WriteLine("地球が作られました。");
        }

        public static Earth getInstance()
        {
            if(Earth.own == null)
            {
                Earth.own = new Earth();
                Earth.own.creator = "神";
            }

            return Earth.own;
        }

        public string getCreatorName()
        {
            return this.creator;
        }

        public void setCreatorName(string gname)
        {
            this.creator = gname;
        }
    }

    public class Terminal
    {
        public static void Main(string[] args)
        {
            Earth e1 = Earth.getInstance();
            Console.WriteLine("この星(e1)は誰が作ったのか?: {0}", e1.getCreatorName());

            Earth e2 = Earth.getInstance();
            Console.WriteLine("この星(e2)は誰が作ったのか?: {0}", e2.getCreatorName());

            e1.setCreatorName("俺");

            Console.WriteLine("この星(e1)は誰が作ったのか?: {0}", e1.getCreatorName());
            Console.WriteLine("この星(e2)は誰が作ったのか?: {0}", e2.getCreatorName());
        }
    }
}
