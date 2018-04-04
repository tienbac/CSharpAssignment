using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Menu
{
    class Menu
    {
        public void MenuManager()
        {
            Model.StudentModel model = new Model.StudentModel();
            Controller.StudentController controller = new Controller.StudentController();
            Console.WriteLine("<==============================>");
            Console.WriteLine("<==== STUDENT MAMAGER MENU ====>");
            Console.WriteLine("<==============================>");
            Console.WriteLine("<=      1 : List Student      =>");
            Console.WriteLine("<=      2 : Find Student      =>");
            Console.WriteLine("<=      3 : Add Student       =>");
            Console.WriteLine("<=      4 : Update Student    =>");
            Console.WriteLine("<=      5 : Delete Student    =>");
            Console.WriteLine("<=      6 : EXIT              =>");
            Console.WriteLine("<==============================>\n");
            Console.Write("Enter your choice: ");
            Console.Write("Fuck u bict");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    model.SelectData();
                    break;
                case 2:
                    controller.FindStudent();
                    //model.FindData();
                    break;
                case 3:
                    controller.AddStudent();
                    break;
                case 4:
                    controller.UpdateStudent();
                    break;
                case 5:
                    controller.DeleteStudent();
                    break;
                case 6:
                    Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choice from 1 to 6! Thank you!");
                    break;
            }
        }
    }
}
