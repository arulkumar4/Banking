using System;

namespace Banking.Business.Models.Account
{
    public class CustomerAccount
    {
        public string Id { get; set; }
        public long Number { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public int AccountTypeId { get; set; }
        public bool Status { get; set; }
        public DateTime OpenDate { get; set; }
        public string FullName { get; set; }

    }
}
