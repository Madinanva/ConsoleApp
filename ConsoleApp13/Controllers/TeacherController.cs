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
    public class TeacherController
    {
        private TeacherRepository _teacherRepository;
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        public void CreateTeacher()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher name:");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher surname:");
            string surname = Console.ReadLine();
          Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher age:");
            string age = Console.ReadLine();
            byte teacherAge;
            var result = byte.TryParse(age, out teacherAge);
            if (result)
            {
                var teacher = new Teacher
                {
                    Name = name,
                    Surname = surname,
                    Age = teacherAge
                };

                var dbTeacher = _teacherRepository.Create(teacher);
                if (dbTeacher != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"{dbTeacher.Name} {dbTeacher.Surname} is created");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Something went wrong");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct age");
                goto Age;
            }
        }
        public void GetAllTeachersByGroup()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list:");

                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id: {teacher.Id}, Fullname: {teacher.Name} {teacher.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }
        public void UpdateTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list:");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id: {teacher.Id}, Fullname: {teacher.Name} {teacher.Surname}");
                }

              Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter teacher id:");
                string id = Console.ReadLine();
                int teacherId;
                var result = int.TryParse(id, out teacherId);
                if (result)
                {
                    var dbTeacher = _teacherRepository.Get(t => t.Id == teacherId);
                    if (dbTeacher != null)
                    {
                        string oldName = dbTeacher.Name;
                        string oldSurname = dbTeacher.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher's new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher's new surname");
                        string newSurname = Console.ReadLine();
                      NewAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher's new age");
                        string newAge = Console.ReadLine();
                        byte teacherNewAge;
                        result = byte.TryParse(newAge, out teacherNewAge);
                        if (result)
                        {
                            var updatedTeacher = new Teacher
                            {
                                Id = dbTeacher.Id,
                                Name = newName,
                                Surname = newSurname,
                                Age = teacherNewAge
                            };

                            _teacherRepository.Update(updatedTeacher);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname} is updated to {updatedTeacher.Name} {updatedTeacher.Surname}");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct age");
                            goto NewAge;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }
        public void DeleteTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All Teachers List");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id: {teacher.Id} Fullname: {teacher.Name} {teacher.Surname}");
                }

              Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher id:");
                string id = Console.ReadLine();
                int teacherId;
                var result = int.TryParse(id, out teacherId);

                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher != null)
                    {
                        string fullName = $"{teacher.Name} {teacher.Surname}";
                        _teacherRepository.Delete(teacher);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }
        public void AddGroupToTeacher()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                var teachers = _teacherRepository.GetAll();
                if (teachers.Count > 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list");

                    foreach (var teacher in teachers)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id: {teacher.Id}, Fullname: {teacher.Name} {teacher.Surname}");
                    }

                 Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher id:");
                    string id = Console.ReadLine();
                    int teacherId;
                    var result = int.TryParse(id, out teacherId);

                    if (result)
                    {
                        var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                        if (teacher != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All groups list");

                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"Id: {group.Id}, Name: {group.Name}");
                            }

                          GroupId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group id:");
                            string groupid = Console.ReadLine();
                            int groupId;
                            result = int.TryParse(groupid, out groupId);
                            if (result)
                            {
                                var group = _groupRepository.Get(g => g.Id == groupId);
                                if (group != null)
                                {
                                    if (group.Teacher == null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"{group.Name} is successfully added to {teacher.Name}");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"This group has already teacher: {group.Teacher.Name} {group.Teacher.Surname}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this id");
                                    goto GroupId;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                                goto GroupId;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a group before adding group to teacher");
            }
        }
        public void GetAllGroupsByTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teachers list");

                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id: {teacher.Id}, Fullname: {teacher.Name} {teacher.Surname}");
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher id:");
                string id = Console.ReadLine();
                int teacherId;
                var result = int.TryParse(id, out teacherId);

                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher != null)
                    {
                        var groups = _groupRepository.GetAll(g => g.Teacher != null ? g.Teacher.Id == teacher.Id : false);
                        if (groups.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The groups of teacher");

                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id: {group.Id}, Name: {group.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher has no group");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct id");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }

    }
}

