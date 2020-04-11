using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface IAccountBl
    {
        List<Customer> GetAllCustomerAccounts();
        List<Customer> GetCustomerAccounts(long customerId, long accountNo);
        List<Customer> GetAccountbyAccountType(string accountType);
        List<Customer> GetAccountByBalance(decimal balance);
        List<Customer> GetCustomerByAccountStatus(bool status);
        List<Customer> UpdateCustomerByEmployee(Customer customer);
        string UpdateAccountPassword(Customer customer);
        string DeleteCustomerAccount(long number, string pass);
    }
}