using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class LoginScreen
    {
        public static void Run()
        {
            string choice = "100";
            List<string> answers = new List<string>(new string[] { "0", "1"});
            while (true)
            {
                Console.WriteLine("\n\n\n\n----- Welcome to our Chat platform ------\n\n");

                Console.WriteLine(" 1. Login \n\n 0. Exit\n\n");
                Console.Write("Please make your choice : ");
                string input = Console.ReadLine();
                choice = input;
                if (!answers.Contains(choice))
                {
                    Console.WriteLine("\nPlease choose a number that corresponds to the choices above : \n");
                }
            
                if(choice=="1") Login();
                else if(choice == "0")  Exit();
                       
            }
            
        }
        public static void Login()
        {
            int s;
            string un,ps;
            while (true)
            {
                Console.WriteLine("\n\n\n Please insert your credentianls");
                Console.Write("` Username : ");
                un = Console.ReadLine();
                Console.Write(" Password : ");
                ps = Console.ReadLine();
                s = Database_access.validate_user(un, ps);
                if (s == -2)
                    Console.WriteLine("\n\n The user was not found, please try again \n\n");
                else
                    break;
            }
            Application_menus.Show_user_menu(s, un);
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
