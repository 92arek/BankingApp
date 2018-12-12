using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTransferManager.Models;

namespace BankTransferManager.Services
{
    public class LoginService
    {
        private readonly List<User> users;

        public LoginService(List<User> users)
        {
            this.users = users;
        }

        public User LoginUser(string name, string password)
        {
            return users.SingleOrDefault(u => u.Name == name && u.Password == password);
        }

    }
}
 