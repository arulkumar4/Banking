using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface IAccountBl
    {
        List<Customer> GetAllCustomerAccounts();
        List<Customer> GetCustomerAccounts(long customerId, long accountNo, string password);
        List<Customer> GetAccountbyAccountType(string accountType);
        List<Customer> GetAccountByBalance(decimal balance);
        List<Customer> GetCustomerByAccountStatus(bool status);
        string UpdateAccountPassword(long accnumber, string oldpassword, string newpassword);
        string DeleteCustomerAccount(Customer account);
    }
}