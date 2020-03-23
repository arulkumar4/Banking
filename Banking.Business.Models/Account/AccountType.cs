using System;

namespace Banking.Business.Models.Account
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal MinimumBalance { get; set; }
        public decimal TransactionLimit { get; set; }

    }
}