using Common;
using System;

namespace ConsoleProjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MailBox mb = new MailBox();
                mb.SendMail("trungnguyen.1997270710@gmail.com", "Tui test cai gui mail", "Test thanh cong");
            }
            catch
            {
                Console.WriteLine("Test that bai roi");
            }
            Console.ReadLine();
        }
    }
}
