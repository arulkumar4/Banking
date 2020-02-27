using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Models.Account
{
    public class CustomerAccount
    {
        public long CustomerId { get; set; }
        public long AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
