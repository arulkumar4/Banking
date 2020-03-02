using System;

namespace Banking.Business.Models.Account
{
    public class CustomerAccount
    {
        public long CustomerId { get; set; }
        public long Number { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public int AccountType { get; set; }
        public int AccountTypeId { get; set; }
        public bool AccountStatus { get; set; }
        public DateTime OpenDate { get; set; }
        public string ContactNumber { get; set; }
        public string Mail { get; set; }
        public string FullName { get; set; }

    }
}
