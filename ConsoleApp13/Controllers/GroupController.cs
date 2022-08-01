using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class GroupController
    {
        private GroupRepository _groupRepository;
        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }

        #region CreateGroup
        public void CreateGroup()
        {
        Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group == null)
            {
            MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group maxSize");
                string size = Console.ReadLine();
                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    Group newGroup = new Group
                    {
                        Name = name,
                        MaxSize = maxSize
                    };
                    var createdGroup = _groupRepository.Create(newGroup);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is succesfully created with maxSize -{createdGroup.MaxSize}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please Enter Correct Group maxSize");
                    goto MaxSize;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "This group already exist");
                goto Name;
            }
        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");
                foreach (var dbGroup in groups)
                {
                    Console.WriteLine($"Id: {dbGroup.Id}, Name:{dbGroup.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group id:");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.Id == chosenId);
                    if (group != null)
                    {
                        int oldSize = group.MaxSize;
                        string oldName = group.Name;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group name ");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, " Enter new group max size");
                        string size = Console.ReadLine();

                        int maxSize;
                        result = int.TryParse(size, out maxSize);

                        if (result)
                        {
                            var newGroup = new Group
                            {
                                Id = group.Id,
                                Name = newName,
                                MaxSize = maxSize
                            };
                            _groupRepository.Update(newGroup);

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{oldName} Max size: {oldSize} is updated to Name: {newGroup.Name} Max size: {newGroup.MaxSize} ");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size:");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group name:");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id:");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");
            }
        }

        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All Groups");
                foreach (var dbGroup in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id: {dbGroup.Id}, Name: {dbGroup.Name}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Group Id:");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.Id == chosenId);
                    if (group != null)
                    {
                        string name = group.Name;
                        _groupRepository.Delete(group);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesnt exist:");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct group Id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");
            }
        }
        #endregion

        #region AllGroups
        public void AllGroups()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Groups");
            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan,$"Name:{group.Name}, MaxSize:{group.MaxSize}");
            }
        }
        #endregion

        #region GetGroupByName
        public void GetGroupByName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name}, MaxSize:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Group Doesnt Exist");

            }
        }

        #endregion

        #region Exit
        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Thanks for using our application");
        }

        #endregion
    }
}