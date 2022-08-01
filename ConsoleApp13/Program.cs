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
            TeacherController _teacherController = new TeacherController();

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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "11- Create Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "12- Uptade Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "13- Delete Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "14- Get All Teachers by Groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "15- Get All Groups By Teacher ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "16- Add Group to Teacher ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0- Exit");

                    Console.WriteLine("---");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 16)
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
                                case (int)Options.CreateTeacher:
                                    _teacherController.CreateTeacher();
                                    break;
                                    case(int)Options.UptadeTeacher:
                                    _teacherController.UpdateTeacher();
                                    break ;
                                    case (int)Options.DeleteTeacher:
                                    _teacherController.DeleteTeacher();
                                    break;
                                case (int)Options.GetAllTeachersByGroup:
                                    _teacherController.GetAllTeachersByGroup(); 
                                    break ;
                                case (int)Options.GetAllGroupsByTeacher:
                                    _teacherController.GetAllGroupsByTeacher();
                                    break;
                                case (int)Options.AddGroupToTeacher:
                                    _teacherController.AddGroupToTeacher();
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