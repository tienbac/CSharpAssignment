using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMansger.Controller
{
    class StudentController
    {
        Model.StudentModel model = new Model.StudentModel();
        public void AddStudent()
        {
            Boolean check = true;
            DateTime now = DateTime.Now;

            //long created = now.Ticks;

            Console.WriteLine("<===== Add Student =====>");
            string srollNumber = null;
            while (check)
            {
                Console.Write("Student Roll Number: ");
                string roll = Console.ReadLine();
                if (roll.Length >= 6 && roll != null)
                {
                    srollNumber = roll;
                    break;
                }
                Console.WriteLine("Student Roll Number is required!");
            }

            string sname = null;
            while (check)
            {
                Console.Write("Student Name: ");
                string name = Console.ReadLine();
                if (name.Length >= 10 && name != null)
                {
                    sname = name;
                    break;
                }
                Console.WriteLine("Student Name is required!");
            }

            int sgender = 1;
            while (check)
            {
                Console.Write("Student Gender: ");
                int gender = int.Parse(Console.ReadLine());
                if (gender > -1 && gender < 3)
                {
                    sgender = gender;
                    break;
                }
                Console.WriteLine("Student Gender is required!");
            }

            string sphone = null;
            while (check)
            {
                Console.Write("Student Phone: ");
                string phone = Console.ReadLine();
                if (phone.Length >= 11 && phone != null)
                {
                    sphone = phone;
                    break;
                }
                Console.WriteLine("Student Phone is required!");
            }

            string semail = null;
            while (check)
            {
                Console.Write("Student Email: ");
                string email = Console.ReadLine();
                if (email.Length >= 15 && email != null)
                {
                    semail = email;
                    break;
                }
                Console.WriteLine("Student Email is required!");
            }

            string saddress = null;
            while (check)
            {
                Console.Write("Student Address: ");
                string address = Console.ReadLine();
                if (address.Length >= 20 && address != null)
                {
                    saddress = address;
                    break;
                }
                Console.WriteLine("Student Address is required!");
            }

            String createdAt = now.ToString("dd/MM/yyyy hh:mm:ss");

            model.InsertData(srollNumber, sname, sgender, sphone, semail, saddress, createdAt);
        }

        public void UpdateStudent()
        {
            DateTime now = DateTime.Now;
            Boolean check = true;

            Console.WriteLine("<===== Update Information Student =====>");
            Console.Write("Enter Student Roll Number: ");
            string rollNumber = Console.ReadLine();

            Console.WriteLine("\nEnter information update: \n");

            string sname = null;
            while (check)
            {
                Console.Write("Student Name: ");
                string name = Console.ReadLine();
                if (name.Length >= 10 && name != null)
                {
                    sname = name;
                    break;
                }
                Console.WriteLine("Student Name is required!");
            }

            int sgender = 1;
            while (check)
            {
                Console.Write("Student Gender: ");
                int gender = int.Parse(Console.ReadLine());
                if (gender > -1 && gender < 3)
                {
                    sgender = gender;
                    break;
                }
                Console.WriteLine("Student Gender is required!");
            }

            string sphone = null;
            while (check)
            {
                Console.Write("Student Phone: ");
                string phone = Console.ReadLine();
                if (phone.Length >= 11 && phone != null)
                {
                    sphone = phone;
                    break;
                }
                Console.WriteLine("Student Phone is required!");
            }

            string semail = null;
            while (check)
            {
                Console.Write("Student Email: ");
                string email = Console.ReadLine();
                if (email.Length >= 15 && email != null)
                {
                    semail = email;
                    break;
                }
                Console.WriteLine("Student Email is required!");
            }

            string saddress = null;
            while (check)
            {
                Console.Write("Student Address: ");
                string address = Console.ReadLine();
                if (address.Length >= 20 && address != null)
                {
                    saddress = address;
                    break;
                }
                Console.WriteLine("Student Address is required!");
            }

            string updatedAt = now.ToString("dd/MM/yyyy hh:mm:ss");

            model.UpdateData(rollNumber, sname, sgender, sphone, semail, saddress, updatedAt);
        }

        public void DeleteStudent()
        {
            Console.WriteLine("<===== Delete Student =====>\n");
            Console.Write("Enter Student Roll Number you want to delete: ");
            string rollNumber = Console.ReadLine();

            Console.WriteLine("You want to delete student has RollNumber = " + rollNumber);
            Console.WriteLine("<= 0: no \\ 1: yes =>");
            int choice = int.Parse(Console.ReadLine());

            model.DeteleData(rollNumber, choice);
        }

        public void SelectStudent()
        {

        }

        public void FindStudent()
        {
            Console.Write("You want to find student infor has roll number = ");
            string rollNumber = Console.ReadLine();

            Console.WriteLine("<== Student Information has Roll Number = " + rollNumber + " ==>");
            model.FindData(rollNumber);
        }
    }
}
