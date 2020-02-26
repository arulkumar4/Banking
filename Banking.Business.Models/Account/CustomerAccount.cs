using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Models.Account
{
    class CustomerAccount
    {
        public int AccountNumber { get; set; }
        public int InitialDeposit { get; set; }
        public int AccountType { get; set; }
    }
}
