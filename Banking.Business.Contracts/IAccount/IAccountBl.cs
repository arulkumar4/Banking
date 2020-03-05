using Banking.Business.Models.Account;
using System.Collections.Generic;

namespace Banking.Business.Contracts.IAccount
{
    public interface IAccountBl
    {
        List<CustomerAccount> GetAllCustomerAccounts();
        List<CustomerAccount>GetCustomerAccounts(long customerId, long accountNo, string password);
        List<CustomerAccount> GetAccountbyAccountType(string accountType);
        List<CustomerAccount> GetAccountByBalance(decimal balance);
        List<CustomerAccount> GetCustomerByAccountStatus(bool status);
        string UpdateAccountPassword(long accnumber, string oldpassword, string newpassword);
        string DeleteCustomerAccount(CustomerAccount account);
    }
}