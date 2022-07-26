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
    public class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authenticate()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter admin username:");
            string username = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter admin password:");
            string password = Console.ReadLine();

            var admin = _adminRepository.Get(a => a.Username.ToLower() == username.ToLower() && PasswordHasher.Decyrpt(a.Password) == password);
            return admin;
        }
    }
}
