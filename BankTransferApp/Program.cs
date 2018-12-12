using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.ReadLine();


            var userlist = new List<User>();
            LoginService ls = new LoginService(userlist);

            ls.LoginUser("asd", "asd");

            var stringlist = new List<string>()
            {
                "x1",
                "x2",
                "x3",
                "x1",
                "x4",
                "x5",
                "x2",
            };

            var x1list = stringlist.Where(x => x == "x1");

            var fistValue = stringlist.First();
            var lastValue = stringlist.Last();
            var single = stringlist.Single(x => x == "x4");

            Console.Write(x1list);
            Console.WriteLine(fistValue);
            Console.WriteLine(lastValue);
            Console.WriteLine(single);

            Console.ReadKey();


            var singleError = stringlist.Single(x => x == "x1");

        }
    }
}
