using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    static class Application_menus
    {
        public static void Show_user_menu(int user_role,string username)
        {
            
            while (true)
            {
                bool returntologin = false;
                returntologin = false;
                List<string> show = new List<string>(new string[] { "Edit Users", "Send Messages","View Messages", "Edit Messages", "Delete Messages","Create user" });
                Console.WriteLine();
                int items;
                if (user_role == -1)
                {
                    Console.WriteLine(" 0. " + show[0]);
                    items = 5;
                }
                else items = user_role + 2;
                for (int i = 1; i <= items; i++)
                {
                    Console.WriteLine(" " + i + ". " + show[i]);
                }

                Console.WriteLine(" 6. Logout");
                Console.Write("Selection :");

                string s = "";
                while (true)
                {
                    s = Console.ReadLine();
                    string[] selectionarray = { "0", "1", "2","3", "4" ,"5","6"};
                    if (selectionarray.Contains(s)) break;
                }
                switch (s)
                {

                    case "0":
                        Edit_users();
                        break;

                    case "1":
                        Send(username);
                        break;
                    case "2":
                        View();
                        break;
                    case "3":
                        Edit();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        Create_user();
                        break;

                    case "6":
                        returntologin=true;
                        break;
                    
                }
                if (returntologin) break;
                
            }
        }
        public static void show_users()

        {
            string qs = "SELECT [username] FROM [ChatDB].[dbo].[Users]";
            List<string> resultlist = new List<string>();
            
            resultlist = Database_access.queryDB(qs);

            Console.WriteLine("\n\n --- Edit Users ---\n\n");

            for (int i = 0; i < resultlist.Count(); i++)
            {
                Console.WriteLine("\n" + i + ". " + resultlist[i] + "\n");
            }
        }
        public static List<string> get_users()

        {
            string qs = "SELECT [username] FROM [ChatDB].[dbo].[Users]";
            List<string> resultlist = new List<string>();

            resultlist = Database_access.queryDB(qs);
            return resultlist;
        }
        public static void Edit_users()
        {
            while (true)
            {

                show_users();
                List<string> resultlist = get_users();
                Console.Write("\n\n User number to edit : ");
                string number = Console.ReadLine();
                int n = System.Int32.Parse(number);

                // so the user to edit is in resultlist[n]

                Console.WriteLine("\n\n Choices for user " + resultlist[n]);
                Console.WriteLine("\n 1. Change username \n");
                Console.WriteLine("\n 2. Change password \n");
                Console.WriteLine("\n 3. Change role \n ");
                Console.WriteLine("\n 4. Cancel");

                Console.Write("\n Choice : ");
                string choice = Console.ReadLine();
                string updatequery = ""; 
                switch (choice)
                {
                    case "1":
                        Console.Write("New username for the user " + resultlist[n] + " : ");
                        string newuser = Console.ReadLine();
                        updatequery = "update [ChatDB].[dbo].[Users] set username='" + newuser + "' where username='" + resultlist[n] + "'";
                        Database_access.updateDB(updatequery);
                        Console.WriteLine("User " + resultlist[n] + " has been updated");
                        break;
                    case "2":
                        Console.Write("New password for the user " + resultlist[n] + " : ");
                        string newpass = Console.ReadLine();
                        updatequery = "update [ChatDB].[dbo].[Users] set password='" + newpass + "' where username='" + resultlist[n] + "'";
                        Database_access.updateDB(updatequery);
                        Console.WriteLine("User " + resultlist[n] + " has been updated");
                        break;
                    case "3":
                        while (true)
                        {
                            Console.WriteLine("Change role for the user " + resultlist[n] + " : ");
                            Console.WriteLine("0. view");
                            Console.WriteLine("1. view, edit");
                            Console.WriteLine("2. view, edit,delete");

                            Console.Write("Please select an appropreate number from -1 to 2 : ");
                            string newrole = Console.ReadLine();
                            int nr;
                            bool success =int.TryParse(newrole, out nr);
                            if (success)
                            {
                                updatequery = "update [ChatDB].[dbo].[Users] set role='" + nr + "' where username='" + resultlist[n] + "'";
                                Database_access.updateDB(updatequery);
                                Console.WriteLine("User " + resultlist[n] + " has been updated");
                                break;
                            }
                            else Console.WriteLine("invalid choice, please try again");
                        }

                        break;
                    case "4":
                        Console.WriteLine("------ Process Canceled --------");
                        break;
                }
                
              
                Console.Write("press Y to edit another user or any other key to exit : ");
                string responce = Console.ReadLine();
                if (responce != "Y")
                    break;

            }

        }
        public static void Create_user()
        {
            while (true)
            {
                Console.WriteLine("\n\n\n Please insert the credentials for the new user");
                Console.Write(" Username : ");
                string un = Console.ReadLine();
                Console.Write(" Password : ");
                string ps = Console.ReadLine();
                string qs = "SELECT [username] FROM [ChatDB].[dbo].[Users] where  [username] ='" + un + "'";
                string insertqs = "insert into[ChatDB].[dbo].[Users] (username,password,role) values('" + un + "','" + ps + "',0)";
                List<string> resultlist = new List<string>();
                resultlist = Database_access.queryDB(qs);
                if (resultlist.Count() > 0)
                    Console.WriteLine("User already exists, please select another user");
                else

                {
                    Database_access.updateDB(insertqs);
                    Console.WriteLine("User Succesfully created");
                    break;
                }
            }
        }


        public static void Send(string user)
        {
            Console.WriteLine("Who do you wish to send a message to ? ");
            show_users();
            Console.Write("Username : ");
            string  receiver = Console.ReadLine();
            if (!(Database_access.validate_user(receiver)))
                Console.WriteLine(" The user is not valid");
            else

            {
                Console.Write("\n Message : \n\n");
                string mes = Console.ReadLine();
                //send the message

                //1.new record in DB
                string curr_date = DateTime.Now.ToString("yyyyMMdd");
                string newsms = "insert into [ChatDb].[dbo].[Messages] (DateOfSubmission,Sender,Receiver,MessageData) " +
                    " values ('" + curr_date+ "','" + user + "','" + receiver + "','" + mes + "')";
                Database_access.updateDB(newsms);
                //2.save to file
                string filename = user + "_" + receiver + "_" + curr_date;
                string path= Directory.GetCurrentDirectory()+@"\Messages\"+filename+".txt";
                if (!Directory.Exists(path))
                    File.WriteAllText(path,mes+"\n");
                else
                    File.AppendAllText(path, mes + "\n");


            }
                



        }
        public static void View()
        {
            string qs = "SELECT [MessageID],[DateOfSubmission],[Sender],[Receiver],[MessageData]  FROM [ChatDb].[dbo].[Messages]";
            List<message> msglist = Database_access.query_msg_DB(qs);
            Console.WriteLine("Message ID\t\tDate\t\tSender\t\tReceiver\t\tMessage");
            for (int i=0;i<msglist.Count();i++)
            {
                Console.WriteLine(msglist[i].MessageID + "\t\t" + msglist[i].DateOfSubmission+"\t"+msglist[i].Sender+ "\t\t" + msglist[i].Receiver+ "\t\t" + msglist[i].Message_Data);
            }

        }
        public static void Edit()
        {
            string qs = "SELECT [MessageID],[DateOfSubmission],[Sender],[Receiver],[MessageData]  FROM [ChatDb].[dbo].[Messages]";
            List<message> msglist = Database_access.query_msg_DB(qs);
            Console.WriteLine("Message ID\t\tDate\t\tSender\t\tReceiver\t\tMessage");
            for (int i = 0; i < msglist.Count(); i++)
            {
                Console.WriteLine(msglist[i].MessageID + "\t\t" + msglist[i].DateOfSubmission + "\t\t" + msglist[i].Sender + "\t\t" + msglist[i].Receiver + "\t\t" + msglist[i].Message_Data);
            }

            Console.Write("MessageId To Edit : ");
            string answer = Console.ReadLine();
            int n = 0;
            bool correct = int.TryParse(answer,out n);
            if (correct)
                try
                {

                    //edit the message
                    Console.Write("\nwrite new message : ");
                    string newmsg = Console.ReadLine();

                    //write in sql
                    string updatequery = "update [ChatDb].[dbo].[Messages] set [MessageData]='" + newmsg + "' where MessageID='" + n + "'";
                    Database_access.updateDB(updatequery);
                    Console.WriteLine("Message has been updated");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry, wrong MessageID : "+e.Message);
                }
         }
        public static void Delete()
        {
            string qs = "SELECT [MessageID],[DateOfSubmission],[Sender],[Receiver],[MessageData]  FROM [ChatDb].[dbo].[Messages]";
            List<message> msglist = Database_access.query_msg_DB(qs);
            Console.WriteLine("Message ID\tDate\tSender\tReceiver\tMessage");
            for (int i = 0; i < msglist.Count(); i++)
            {
                Console.WriteLine(msglist[i].MessageID + "\t" + msglist[i].DateOfSubmission + "\t" + msglist[i].Sender + "\t" + msglist[i].Receiver + "\t" + msglist[i].Message_Data);
            }

            Console.Write("Message ID to delete : ");
            string answer = Console.ReadLine();
            int n = 0;
            bool correct1 = int.TryParse(answer, out n);
            if (correct1)
                try
                {
                    //delete the message
                    string deletequery = "delete from [ChatDb].[dbo].[Messages] where MessageID = '" + n + "'";
                    Database_access.updateDB(deletequery);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry wrong MessageID : "+e.Message);
                }
        }

        public static bool Previous()
        {
            LoginScreen.Run();
            return true;
        }

    }
}
