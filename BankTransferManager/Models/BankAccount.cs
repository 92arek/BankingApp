using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferManager.Models
{
    public class BankAccount
    {
        public int AccountId { get; set; }
        public int Balance { get; set; }

        public User User { get; set; }
    }
}
