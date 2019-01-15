using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTransferManager.Services;

namespace BankTransferApp
{
    public class UserController
    {
        private readonly LoginService loginService;

        public UserController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        public void LoginAction(string userName, string password)
        {
            try
            {
                var user = loginService.LoginUser(userName, password);
                Console.WriteLine($"{user.Name} {user.Surname}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Username or password is incorrect.");
              
            }
            
        }
    }
}
