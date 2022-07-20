using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            GroupRepository _groupRepository = new GroupRepository();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Welcome");
            Console.WriteLine("---");
            while(true)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1- Create Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2- Uptade Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3- Delete Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4- All Groups");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5- Get Group By Name");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0- Exit");
                Console.WriteLine("---");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if(result)
                {
                  if(selectedNumber >= 0 && selectedNumber <= 5)
                    {
                        switch(selectedNumber)
                        {
                            case (int)Options.CreateGroup:
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group Name");
                                string name = Console.ReadLine();
                                MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group maxSize");
                                string size = Console.ReadLine();
                                int maxSize;
                                result = int .TryParse(size, out maxSize);
                                if(result)
                                {
                                    Group group = new Group
                                    {
                                        Name = name,
                                        MaxSize = maxSize
                                    };
                                   var createdGroup = _groupRepository.Create(group);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is succesfully created with maxSize -{createdGroup.MaxSize}");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter Correct Group maxSize");
                                    goto MaxSize;
                                }
                                break;
                            case (int)Options.UptadeGroup:
                                break;
                            case (int)Options.DeleteGroup:
                                break;
                            case (int)Options.AllGroups:
                                var groups = _groupRepository.GetAll();
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Groups");
                                foreach (var group in groups)
                                {
                                    Console.WriteLine($"{group.Name}, {group.MaxSize}");
                                }
                                break;
                            case (int)Options.GetGroupByName:
                                break;
                            case (int)Options.Exit:

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow,"Thanks for using our application");
                                return;
                        }
                    }

                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                    }
                }
            }
            
        }
    }
}