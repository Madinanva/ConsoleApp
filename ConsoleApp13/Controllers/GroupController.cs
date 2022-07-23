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
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group Name");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter Group maxSize");
            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
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
        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                int oldSize = group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group name ");
                string newName = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, " Enter new group max size");
                string size = Console.ReadLine();

                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize
                    };
                    _groupRepository.Update(newGroup);

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{name} Max size: {oldSize} is updated to Name: {newName} Max size: {maxSize} ");
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

        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Group Name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group != null)
            {
                _groupRepository.Delete(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Group Doesnt Exist:");
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
                Console.WriteLine($"{group.Name}, {group.MaxSize}");
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
