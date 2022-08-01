﻿using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private static int id;
        public Teacher Create(Teacher entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Teachers.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Teacher entity)
        {
            try
            {
                DbContext.Teachers.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Teacher Get(Predicate<Teacher> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Teachers[0];
                }
                else
                {
                    return DbContext.Teachers.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Teacher> GetAll(Predicate<Teacher> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Teachers;
                }
                else
                {
                    return DbContext.Teachers.FindAll(filter);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Teacher entity)
        {
            try
            {
                var student = DbContext.Teachers.Find(g => g.Id == entity.Id);
                if (student != null)
                {
                    student.Name = entity.Name;
                    student.Surname = entity.Surname;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
