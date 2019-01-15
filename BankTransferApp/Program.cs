using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BankTransferManager.Models;
using BankTransferManager.Services;

namespace BankTransferApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var allUsers = UsefulData.ReturnAllUsers();
            var loginService = new LoginService(allUsers);
            var userController = new UserController(loginService);

            string userName;
            string userPassword;

            Console.WriteLine("Enter username: ");
            userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter password: ");
            userPassword = Console.ReadLine();

            userController.LoginAction(userName, userPassword);

            Console.ReadKey();
        }
    }

    public static class UsefulData
    {
        public static List<User> ReturnAllUsers()
        {
            var users = new List<User>()
            {
                new User() {Id = 1,Name = "John", Surname = "Smith", Password = "john1smith"},
                new User() {Id = 2, Name = "Tom", Surname = "Miller", Password = "tom2miller"},
                new User() {Id = 3, Name = "Ann", Surname = "Green", Password = "ann3green"}
            };

            return users;
        }
    }
}



#region old
//Console.ReadLine();


//var userlist = new List<User>();
//LoginService ls = new LoginService(userlist);

//ls.LoginUser("asd", "asd");

//var stringlist = new List<string>()
//{
//"x1",
//"x2",
//"x3",
//"x1",
//"x4",
//"x5",
//"x2",
//};

//var x1list = stringlist.Where(x => x == "x1");

//var fistValue = stringlist.First();
//var lastValue = stringlist.Last();
//var single = stringlist.Single(x => x == "x4");

//Console.Write(x1list);
//Console.WriteLine(fistValue);
//Console.WriteLine(lastValue);
//Console.WriteLine(single);
#endregion
