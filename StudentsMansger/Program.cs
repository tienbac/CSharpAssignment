using System;

namespace StudentsMansger
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Menu menu = new Menu.Menu();
            Boolean check = true;
            //Tien Bac
            while (check)
            {
                Menu.Menu mn = new Menu.Menu();
                mn.MenuManager();

                Console.WriteLine("\n Do you want to continue?");
                Console.WriteLine("<=========================>");
                Console.WriteLine("||         0: NO         ||");
                Console.WriteLine("||         1: YES        ||");
                Console.WriteLine("<=========================>\n");
                Console.Write("Your action is: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("                       ");
                    continue;
                }
                else if (choice == 0)
                {
                    Model.ConnectionHelper.GetConnection().Close();
                    Model.ConnectionHelper.GetConnection().Dispose();
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("Please choice 0: NO \\ 1: YES !");
                    continue;
                }
            }
        }
    }
}
