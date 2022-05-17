// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UserLogin
{
    public class Program
    {

        static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!! " + errorMsg + " !!");
        }

        public static void AdministratorPanel()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Assign a new role to a user");
            Console.WriteLine("2: Change valid date for a user");
            Console.WriteLine("3: List with all the users");
            Console.WriteLine("4: View Log Activity");
            Console.WriteLine("5: View current activity\n");

            int choose;
            string findUser;
            int newUserRole;
            DateTime userDateTime;
            choose = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> allusers = UserData.AllUsersUsernames();

            switch (choose)
            {
                case 0:
                    Console.WriteLine("You have exited the Administration Panel");
                    break;

                case 1:
                    Console.Write("Enter the user you want to change the user role: ");
                    findUser = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter the new role: ");
                    newUserRole = Console.Read();
                    UserData.AssignUserRole(allusers[findUser], (UserRoles)newUserRole);
                    break;

                case 2:
                    Console.Write("Enter the user you want to change the validation date: ");
                    findUser = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter the new validation date: ");
                    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                    {

                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect date.");
                    }
                    UserData.SetUserActiveTo(allusers[findUser], userDateTime);
                    break;

                case 3:
                    for (int i = 0; i < allusers.Count; i++)
                    {
                        Console.WriteLine(allusers.ElementAt(i).Key);
                    }

                    break;

                case 4:
                    string readText = File.ReadAllText("test.txt");
                    Console.WriteLine(readText);
                    break;

                case 5:
                    Console.WriteLine("Enter filter: ");
                    string filter = Console.ReadLine();
                    Logger.GetCurrentSessionActivities(filter);
                    break;

                default:
                    Console.WriteLine("The entered value is not correct");
                    break;

            }
        }

        public static void Main()
        {
            String tempName = null, tempPw = null;
            User John;
            User Webber = new User("Webber", "123b566", 1231458, 1);
            User tempUser = new User();

            Console.Write("Enter your username: ");
            tempName = Console.ReadLine();
            tempUser.name = tempName;

            Console.Write("Enter you password: ");
            tempPw = Console.ReadLine();
            tempUser.password = tempPw;

            LoginValidation validator = new LoginValidation(tempName, tempPw, ActionOnError);


            if (validator.ValidateUserInput(ref tempUser) == true)
            {
                Console.WriteLine("\nAdministrator");
                Console.WriteLine(tempUser.name + " " + tempUser.password + " " + tempUser.facultyNum + " " + tempUser.role + "\n");
                AdministratorPanel();
            }

            Console.WriteLine();
            Console.Write("Role: ");

            switch ((int)LoginValidation.currentUserRole)
            {
                case 0:
                    Console.WriteLine("Anonymous"); break;

                case 1:
                    Console.WriteLine("Admin"); break;

                case 2:
                    Console.WriteLine("Inspector"); break;

                case 3:
                    Console.WriteLine("Professor"); break;

                case 4:
                    Console.WriteLine("Student"); break;

                default:
                    Console.WriteLine("Do not know"); break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            //("pause");
            // return 0;
        }


    }

}

