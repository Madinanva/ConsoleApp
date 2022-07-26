using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            GroupController _groupController = new GroupController();
            StudentController _studentController = new StudentController();
            AdminController _adminController = new AdminController();

        Authentication: var admin = _adminController.Authenticate();
            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Welcome");
                Console.WriteLine("---");
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1- Create Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2- Update Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3- Delete Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4- All Groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5- Get Group By Name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6- Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "7- Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "8- Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "9- All Students by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "10- Get All Students by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0- Exit");
                    Console.WriteLine("---");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 10)
                        {
                            switch (selectedNumber)
                            {
                                #region CreateGroup
                                case (int)Options.CreateGroup:
                                    _groupController.CreateGroup();
                                    break;
                                #endregion
                                case (int)Options.UptadeGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                #region AllGroups
                                case (int)Options.AllGroups:
                                    _groupController.AllGroups();
                                    break;
                                #endregion
                                case (int)Options.GetGroupByName:
                                    _groupController.GetGroupByName();
                                    break;
                                case (int)Options.Exit:

                                    _groupController.Exit();
                                    break;
                                case (int)Options.CreateStudent:
                                    _studentController.CreateStudent();
                                    break;
                                case (int)Options.UptadeStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)Options.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)Options.AllStudentsByGroup:
                                    _studentController.AllStudentsByGroup();
                                    break;
                                case (int)Options.GetAllStudentsByGroup:
                                    _studentController.GetAllStudentsByGroup();
                                    break;

                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                    }
                
                   
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;

            }
        }
    }
}